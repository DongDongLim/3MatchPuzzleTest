using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IMove
{
    void OnMove(int targetIndex, UnityAction endAction);
}
