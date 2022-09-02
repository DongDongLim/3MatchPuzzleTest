using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class TileCheck
{

    ILineCheck m_LineCheck;

    ICrossCheck m_CrossAllCheck;


    List<Tile> m_matchTile;

    Mutex<TileCheck> m_Mutex;

    public bool isInit;

    public TileCheck()
    {
        m_LineCheck = new LineCheckRay();
        m_CrossAllCheck = new CrossCheckAll();
        m_matchTile = new List<Tile>(SharedData.instance.MaxWidth * 2);
        m_Mutex = new Mutex<TileCheck>();
    }

    public void InitLineCheckAll()
    {
        if (isInit)
            return;
        ReSetChecking(true);
        ReSetChecking(false);
        isInit = true;
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
        if (!IsMatchTile())
            return;
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
        UseMonoBehaviour.instance.OnStartCoroutine(ReActiveTile());
    }

    List<Tile> m_MoveTile = new List<Tile>(9);
    List<Tile> m_TileMove = new List<Tile>(20);

    public IEnumerator  ReActiveTile()
    {
        m_TileMove.Clear();
        foreach (var node in SharedData.instance.m_emptyNodes)
        {
            if (node.Value.Count == 0)
                continue;

            node.Value.Sort();

            m_LineCheck.LineChecking(false, node.Key, m_MoveTile, false, node.Value[node.Value.Count - 1]);
            
            foreach (var hit in m_MoveTile)
            {
                hit.m_PositionIndex = hit.m_PositionIndex + (node.Value.Count * SharedData.instance.MaxWidth);
                m_TileMove.Add(hit);
            }

            //for (int i = 1; i <= node.Value.Count; ++i)
            //{
            //    GameObject obj = SharedData.instance.TileMaker.ActiveTile(node.Key + (SharedData.instance.MaxWidth * (node.Value.Count - i)));
            //    obj.transform.position = SharedData.instance.GetNodePosition(node.Key) + (Vector2.up * SharedData.instance.NodeDis * i);
            //    m_TileMove.Add(obj.GetComponent<Tile>());
            //}

            yield return null;
            
            m_MoveTile.Clear();
        }
        for (int i = 0; i < SharedData.instance.MaxWidth; ++i)
            SharedData.instance.m_emptyNodes[i].Clear();

        yield return null;

        foreach (var move in m_TileMove)
        {
            move.GetComponent<IMove>().OnMove(move.m_PositionIndex, move.MoveAction);
        }
        yield return new WaitForSeconds(0.5f);

        MatchTileBreak();
    }



}