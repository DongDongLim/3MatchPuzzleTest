using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;


public class SwapControllerIMove : SwapController
{
    UnityAction m_Action;

    int m_actionCount;
    public SwapControllerIMove()
    {
        m_actionCount = 0;
        m_swap = new SwapTileIMove();
    }
    public override void OnSwap(Tile firstTile, Tile secondTile, UnityAction action)
    {
        m_Action = action;
        m_swap.OnSwap(firstTile, secondTile, MoveAction);
    }

    public void MoveAction()
    {
        ++m_actionCount;
        if (m_actionCount == 2)
        {
            m_Action?.Invoke();
            m_actionCount = 0;
        }
    }
}
