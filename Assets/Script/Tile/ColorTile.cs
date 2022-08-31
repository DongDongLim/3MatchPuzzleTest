using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ColorTile : Tile, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IMove
{
    Color[] m_color = { Color.red, Color.green, Color.blue, Color.black, Color.white, Color.yellow };

    [SerializeField]
    Image m_TileImg;

    List<int> exIndex = new List<int>();

    UnityAction m_MoveEndAction;

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

    public void OnMove(int targetIndex, UnityAction endAction)
    {
        m_MoveEndAction = endAction;
        StartCoroutine(CorTileMove(targetIndex));
    }

    IEnumerator CorTileMove(int targetIndex)
    {
        float t = 0;
        Vector2 startPosition = transform.position;
        while(t <= 1)
        {
            t += Time.deltaTime * SharedData.instance.SwapSpeed;
            transform.position = Vector2.Lerp(startPosition, SharedData.instance.GetNodePosition(targetIndex), t);
            yield return null;
        }
        m_MoveEndAction?.Invoke();
    }
}
