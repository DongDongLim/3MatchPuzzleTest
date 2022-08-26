using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    [SerializeField]
    GameObject m_CharPrefab;
    GameObject m_activeObj;
    ObjectPooling m_Pooling;
    

    private void Awake()
    {
        m_Pooling = new ObjectPooling();
    }

    private void Start()
    {
        CreateChar();
    }

    private void CreateChar()
    {
        for (int i = 0; i < SharedData.instance.MaxPoolCount; ++i)
        {
            m_Pooling.Push(Instantiate(m_CharPrefab, transform, false));
            ActiveChar(i).transform.position = SharedData.instance.GetNodePosition(i);
        }
    }

    public GameObject ActiveChar(int index)
    {
        m_activeObj = m_Pooling.Pop();
        m_activeObj.GetComponent<Tile>().m_PositionIndex = index;
        m_activeObj.SetActive(true);
        return m_activeObj;
    }

    public void InActiveChar(GameObject obj)
    {
        m_Pooling.Push(obj);
    }
}
