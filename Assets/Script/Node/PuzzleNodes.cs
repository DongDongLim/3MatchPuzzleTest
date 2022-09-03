using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleNodes : MonoBehaviour
{
    [SerializeField]
    public Tile tilePrefab;

    protected int[,] m_NodeIndexs;
    protected int m_MaxWidth;
    protected int m_MaxHeight;

    public abstract int GetNodeType(int index);
    public abstract Vector2 GetNodePosition(int index);
    public abstract Vector2 GetNodeCoordinate(int index);
}
