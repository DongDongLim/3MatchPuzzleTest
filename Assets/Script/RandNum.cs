using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandNum
{
    public int OvelapRandNum(List<int> exIndex, int count)
    {
        List<int> colorIndex = new List<int>();
        for (int i = 0; i < count; ++i)
        {
            if (!exIndex.Contains(i))
                colorIndex.Add(i);
        }
        return colorIndex[Random.Range(0, colorIndex.Count - 1)];
    }


}
