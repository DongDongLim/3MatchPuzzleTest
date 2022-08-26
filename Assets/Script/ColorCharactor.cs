using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorCharactor : Charactor
{
    Color[] m_color = { Color.red, Color.green, Color.blue, Color.black, Color.white, Color.yellow };

    [SerializeField]
    Image m_CharImg;

    private void OnEnable()
    {
        CharNum = Random.Range(0, m_MaxSize);
        m_CharImg.color = m_color[CharNum];
    }
}
