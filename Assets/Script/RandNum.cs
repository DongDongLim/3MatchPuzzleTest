using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandNum
{
    List<int> colorIndex = new List<int>();
    public int OvelapRandNum(List<int> exIndex, int count)
    {
        colorIndex.Clear();
        for (int i = 0; i < count; ++i)
        {
            if (!exIndex.Contains(i))
                colorIndex.Add(i);
        }

        return colorIndex[Random.Range(0, colorIndex.Count)];
    }


}
