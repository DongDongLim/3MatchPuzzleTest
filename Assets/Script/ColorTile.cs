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
        TileNum = Random.Range(0, m_MaxSize);
        m_TileImg.color = m_color[TileNum];
    }
}
