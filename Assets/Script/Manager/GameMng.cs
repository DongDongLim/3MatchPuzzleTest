using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    [SerializeField]
    float m_DelayTime;

    [SerializeField]
    Transform m_TileParant;

    [SerializeField]
    GameObject m_TilePrefab;

    GameObject m_activeObj;
    
    ObjectPooling m_Pooling;

    WaitForSeconds m_CorDelayTime;
    

    private void Awake()
    {
        m_Pooling = new ObjectPooling();
        m_CorDelayTime = new WaitForSeconds(m_DelayTime);
    }

    private void Start()
    {
        CreateTile();
    }

    private void CreateTile()
    {
        for (int i = 0; i < SharedData.instance.MaxPoolCount; ++i)
        {
            m_Pooling.Push(Instantiate(m_TilePrefab, m_TileParant, false));
            
            ActiveTile(i).transform.position
                = new Vector3( SharedData.instance.GetNodePosition(i).x, SharedData.instance.GetNodePosition(i).y, 0);
            m_activeObj.GetComponent<Tile>().m_OnBreakTile = new Tile.OnBreakTile(InActiveTile);
        }
        StartCoroutine(StageStart());
    }

    IEnumerator StageStart()
    {
        yield return m_CorDelayTime;
        SharedData.instance.OnStartGame?.Invoke();
    }

    public GameObject ActiveTile(int index)
    {
        m_activeObj = m_Pooling.Pop();
        m_activeObj.GetComponent<Tile>().m_PositionIndex = index;
        m_activeObj.SetActive(true);
        return m_activeObj;
    }

    public void InActiveTile(Tile tile)
    {
        tile.transform.position = (Vector2)tile.transform.position
            + (Vector2.up * SharedData.instance.NodeDis * (SharedData.instance.GetPuzzleCoordinate(tile.m_PositionIndex).x + 1));
        m_Pooling.Push(tile.gameObject);
    }
}
