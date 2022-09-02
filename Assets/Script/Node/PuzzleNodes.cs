using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleNodes : MonoBehaviour
{
    protected int m_MaxWidth;
    protected int m_MaxHeight;

    public abstract Vector2 GetNodePosition(int index);
    public abstract Vector2 GetNodeCoordinate(int index);
}
