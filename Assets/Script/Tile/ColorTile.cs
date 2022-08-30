using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorTile : Tile, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler
{
    Color[] m_color = { Color.red, Color.green, Color.blue, Color.black, Color.white, Color.yellow };

    [SerializeField]
    Image m_TileImg;

    List<int> exIndex = new List<int>();

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
        CrossCheck();

        exIndex.Clear();

        foreach (var crossTile in m_CrossTile)
            exIndex.Add(crossTile.TileNum);

        Mutex<TileCheck> m_Mutex = tileCheck.GetMutex();

        Init(m_RandNum.OvelapRandNum(exIndex, m_color.Length));

        m_Mutex.Dequeue();

        if (!m_Mutex.Empty())
            m_Mutex.FirstCall(tileCheck);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SwapMng.instance.SetSelectTile(this);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        SwapMng.instance.ClearSelectTile();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SwapMng.instance.SetSwapTile(this);
    }
}
