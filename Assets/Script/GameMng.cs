using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    [SerializeField]
    GameObject m_TilePrefab;
    GameObject m_activeObj;
    ObjectPooling m_Pooling;
    

    private void Awake()
    {
        m_Pooling = new ObjectPooling();
    }

    private void Start()
    {
        CreateTile();
        Invoke("StartTest", 1f);
    }
    void StartTest()
    {
        SharedData.instance.OnStartGame?.Invoke();

    }
    private void CreateTile()
    {
        for (int i = 0; i < SharedData.instance.MaxPoolCount; ++i)
        {
            m_Pooling.Push(Instantiate(m_TilePrefab, transform, false));
            ActiveTile(i).transform.position = new Vector3( SharedData.instance.GetNodePosition(i).x, SharedData.instance.GetNodePosition(i).y, 0);
        }
    }

    public GameObject ActiveTile(int index)
    {
        m_activeObj = m_Pooling.Pop();
        m_activeObj.GetComponent<Tile>().m_PositionIndex = index;
        m_activeObj.SetActive(true);
        return m_activeObj;
    }

    public void InActiveTile(GameObject obj)
    {
        m_Pooling.Push(obj);
    }
}
