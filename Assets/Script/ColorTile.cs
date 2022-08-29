using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorTile : Tile
{
    Color[] m_color = { Color.red, Color.green, Color.blue, Color.black, Color.white, Color.yellow };

    [SerializeField]
    Image m_TileImg;

    private void OnEnable()
    {
        Init(Random.Range(0, m_color.Length));
    }

    private void Init(int num)
    {
        TileNum = num;
        m_TileImg.color = m_color[num];
    }

    public override void ReSetting(TileCheck tileCheck)
    {
        List<int> exIndex = m_CrossCheck.CrossChecking(transform);

        Mutex<TileCheck> m_Mutex = tileCheck.GetMutex();

        Init(m_RandNum.OvelapRandNum(exIndex, m_color.Length));

        m_Mutex.Dequeue();

        if (!m_Mutex.Empty())
            m_Mutex.FirstCall(tileCheck);
    }

    
}
