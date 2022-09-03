using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SharedData : SingleTonOnly<SharedData>
{
    #region 상태 이넘

    public enum EGAMESTATE
    {
        NONE = -1,
        INIT,
        CHECK,
        BREAK,
        STAY,

        SIZE,
    }

    #endregion

    #region 스왑
    [SerializeField]
    private int m_SwapSpeed;
    #endregion

    #region 타일 정보
    [SerializeField]
    private PuzzleNodes m_Nodes;

    [SerializeField]
    private int m_TileSize;

    [SerializeField]
    private int m_MaxWidth;

    [SerializeField]
    private int m_MaxHeight;

    private int m_MaxPoolCount;

    [SerializeField]
    private float m_NodeDis;

    #endregion

    #region 타일 풀링

    [SerializeField]
    private GameObject m_TilePrefab;

    [SerializeField]
    private Transform m_TileParant;

    #endregion

    #region 타일 체크

    private TileCheck m_TileChecker;

    public Dictionary<int, List<int>> m_emptyNodes;

    #endregion

    #region 게임 액션

    public delegate void TileAction(Tile tile);

    public TileAction OnSelectTile;

    public TileAction OnSwapTile;

    public UnityAction OnClearSelectTile;

    #endregion

    public int SwapSpeed { get { return m_SwapSpeed; } }

    public int TileSize { get { return m_TileSize; } }

    public int MaxWidth { get { return m_MaxWidth; } }

    public int MaxHight { get { return m_MaxHeight; } }

    public int MaxPoolCount { get { return m_MaxPoolCount; } }

    public float NodeDis { get { return m_NodeDis; } }

    public GameObject TilePrefab { get { return m_TilePrefab; } }

    public Transform TileParant { get { return m_TileParant; } }


    public int GetNodeIndexs(int height, int width)
    {
        return (height * m_MaxWidth) + width;
    }
    public Vector2 GetNodePosition(int index)
    {
        return m_Nodes.GetNodePosition(index);
    }

    public Vector2 GetNodePosition(int height, int width)
    {
        return m_Nodes.GetNodePosition(GetNodeIndexs(height, width));
    }

    public Vector2 GetPuzzleCoordinate(int index)
    {
        return m_Nodes.GetNodeCoordinate(index);
    }

    protected override void OnAwake()
    {
        m_MaxPoolCount = m_MaxWidth * m_MaxHeight;
        m_TileChecker = new TileCheck();
        m_emptyNodes = new Dictionary<int, List<int>>();
        for (int i = 0; i < MaxWidth; ++i)
        {
            m_emptyNodes.Add(i, new List<int>());
        }
        SetNodeDis();
    }

    public void SetNodeDis()
    {
        m_NodeDis = (GetNodePosition(1) - GetNodePosition(0)).x;
    }
   
    public void CrossTileCheck(Transform tileTransform)
    {
        m_TileChecker.CrossTileCheck(tileTransform);
    }

    public bool MatchTileBreak()
    {
        if (m_TileChecker.IsMatchTile())
        {
            m_TileChecker.MatchTileBreak();
            return true;
        }
        return false;
    }

}
