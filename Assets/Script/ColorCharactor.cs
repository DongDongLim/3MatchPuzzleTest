using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorCharactor : Charactor
{

    Color[] m_color = { Color.red, Color.green, Color.blue };

    [SerializeField]
    Image m_CharImg;


    private void OnEnable()
    {
        SetChar(Random.Range(0, m_MaxSize));
        m_CharImg.color = m_color[GetChar()];
    }
}
