using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeMapGenerator
{
    public static float[,] GenerateEdgeMap(EdgesData edgesData, int size)
    {
        float[,] map = new float[size, size];


        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                float value = 1;
                if (!edgesData.leftEdge)
                {
                    value = Mathf.Min(((float)size / 2 - j) / ((float)size / 2), value);
                }
                if (!edgesData.rightEdge)
                {
                    value = Mathf.Min((j - (float)size / 2) / ((float)size / 2), value);
                }
                if (!edgesData.bottomEdge)
                {
                    value = Mathf.Min(((float)size / 2 - i) / ((float)size / 2), value);
                }
                if (!edgesData.upperEdge)
                {
                    value = Mathf.Min((i - (float)size / 2) / ((float)size / 2), value);
                }
                map[i, j] = value;
            }
        }

        return map;
    }

    static float Evaluate(float value)
    {
        float a = 3;
        float b = 2.2f;

        return Mathf.Pow(value, a) / (Mathf.Pow(value, a) + Mathf.Pow((b - b * value), a));
    }

}

[System.Serializable]
public struct EdgesData
{
    public bool rightEdge;
    public bool leftEdge;
    public bool upperEdge;
    public bool bottomEdge;

}
