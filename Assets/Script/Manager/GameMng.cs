using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    StateAI m_GameStateAI;

    bool isPlaying;

    IEnumerator m_DelayCor;


    private void Awake()
    {
        m_GameStateAI = new GameStateAI();
        isPlaying = true;
        StartCoroutine(CorUpdate());
    }

    IEnumerator CorUpdate()
    {
        m_GameStateAI.InitAI();
        yield return null;
        while (isPlaying)
        {
            m_GameStateAI.m_CurState.StateUpdate();

            if (m_DelayCor != null)
            {
                yield return StartCoroutine(m_DelayCor);
                m_DelayCor = null;
            }

            yield return null;
        }
    }

    public void DelayCor(IEnumerator delayCor)
    {
        m_DelayCor = delayCor;
    }

}
