using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mutex : MonoBehaviour
{
    Queue<UnityAction> m_Array = new Queue<UnityAction>();
    public void Enqueue(UnityAction value)
    {
        m_Array.Enqueue(value);
    }

    public void FirstCall()
    {
        m_Array.Peek()?.Invoke();
    }

    public bool Empty()
    {
        return m_Array.Count == 0;
    }

    public UnityAction Dequeue()
    {
        return m_Array.Dequeue();
    }
}

public class Mutex<T> : MonoBehaviour
{
    Queue<UnityAction<T>> m_Array = new Queue<UnityAction<T>>();
    public void Enqueue(UnityAction<T> value)
    {
        m_Array.Enqueue(value);
    }

    public void FirstCall(T value)
    {
        m_Array.Peek()?.Invoke(value);
    }

    public bool Empty()
    {
        return m_Array.Count == 0;
    }

    public UnityAction<T> Dequeue()
    {
        return m_Array.Dequeue();
    }
}
