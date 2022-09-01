using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileCheck
{

    ILineCheck m_LineCheck;

    ICrossCheck m_CrossAllCheck;

    [SerializeField]
    List<Tile> m_matchTile;

    Mutex<TileCheck> m_Mutex;


    public TileCheck()
    {
        m_LineCheck = new LineCheckRay();
        m_CrossAllCheck = new CrossCheckAll();
        m_matchTile = new List<Tile>(SharedData.instance.MaxWidth * 2);
        m_Mutex = new Mutex<TileCheck>();
        SharedData.instance.OnStartGame += InitLineCheckAll;
    }

    void InitLineCheckAll()
    {
        ReSetChecking(true);
        ReSetChecking(false);
    }

    void ReSetChecking(bool isWidth)
    {
        for (int i = 0; i < (isWidth ? SharedData.instance.MaxWidth : SharedData.instance.MaxHight); ++i)
        {
            m_LineCheck.LineChecking(isWidth, i, m_matchTile);

            if (m_matchTile.Count >= 3)
            {
                for(int j = 0; j < m_matchTile.Count; j += 3)
                {
                    m_Mutex.Enqueue(m_matchTile[j].ReSetting);
                }
                m_matchTile.Clear();
            }
        }
        m_Mutex.FirstCall(this);
    }

    public Mutex<TileCheck> GetMutex()
    {
        return m_Mutex;
    }

    public void CrossTileCheck(Transform tileTransform)
    {
        m_matchTile.AddRange(m_CrossAllCheck.CrossChecking(tileTransform));
    }

    public bool IsMatchTile()
    {
        return m_matchTile.Count != 0;
    }

    public void MatchTileBreak()
    {
        foreach (var tile in m_matchTile)
        {
            if (tile.gameObject.activeSelf)
            {
                Vector2 nodeCoordinate = SharedData.instance.GetPuzzleCoordinate(tile.m_PositionIndex);
                SharedData.instance.m_emptyNodes[(int)nodeCoordinate.y].Add((int)nodeCoordinate.x);
                tile.TileBreak();
            }
        }
        m_matchTile.Clear();
        SharedData.instance.OnStartCoroutine(ReActiveTile());
    }

    RaycastHit2D[] m_rayHit;
    List<GameObject> m_TileMove = new List<GameObject>(20);

    public IEnumerator  ReActiveTile()
    {
        m_TileMove.Clear();
        foreach (var node in SharedData.instance.m_emptyNodes)
        {
            if (node.Value.Count == 0)
                continue;

            for (int i = 0; i < node.Value.Count; ++i)
            {
                GameObject obj = SharedData.instance.TileMaker.ActiveTile(node.Key - (SharedData.instance.MaxWidth * (i + 1)));
                obj.transform.position = (Vector2)obj.transform.position + (Vector2.up * SharedData.instance.NodeDis * i);
            }
            node.Value.Sort();
            yield return null;
            m_rayHit = Physics2D.RaycastAll(SharedData.instance.GetNodePosition(node.Value[node.Value.Count - 1], node.Key),
                Vector2.up, SharedData.instance.NodeDis * (SharedData.instance.MaxHight - 1), LayerMask.GetMask("Tile"));
            foreach (var hit in m_rayHit)
            {
                hit.transform.GetComponent<Tile>().m_PositionIndex = hit.transform.GetComponent<Tile>().m_PositionIndex + (node.Value.Count * SharedData.instance.MaxWidth);
                //hit.transform.GetComponent<IMove>().OnMove(hit.transform.GetComponent<Tile>().m_PositionIndex + (node.Value.Count * SharedData.instance.MaxWidth), null);
                m_TileMove.Add(hit.transform.gameObject);
            }
        }
        foreach(var move in m_TileMove)
        {
            move.GetComponent<IMove>().OnMove(move.GetComponent<Tile>().m_PositionIndex, move.GetComponent<Tile>().MoveAction);
        }
        for (int i = 0; i < SharedData.instance.MaxWidth; ++i)
            SharedData.instance.m_emptyNodes[i].Clear();
    }



}