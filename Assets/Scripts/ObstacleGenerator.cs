using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class wallXPos
{
    public static float left = -1.7f;
    public static float center = 0f;
    public static float right = 1.7f;
}

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    private List<List<int>> wallLines = new List<List<int>>(); 

    void Start()
    {
        SetUpWalls();
        BuildWalls();
    }

    private void SetUpWalls()
    {
        for (int i = 0; i < 7; i++)
        {
            int wallCount = 0;
            List<int> oneLineWalls = new List<int>();

            while (wallCount == 0)
            {
                (wallCount, oneLineWalls) = SetUpWallLine(wallCount, oneLineWalls);
            }

            wallLines.Add(oneLineWalls);
        }
    }

    private Tuple<int, List<int>> SetUpWallLine(int wallCount, List<int> oneLineWalls)
    {
        for (int j = 0; j < 3; j++)
        {
            int wallValue = (int)Mathf.Round(UnityEngine.Random.Range(0f, 1f));
            if (wallValue == 1)
            {
                if (wallCount < 2)
                {
                    wallCount += 1;
                    oneLineWalls.Add(wallValue);
                }
            }
            else
            {
                oneLineWalls.Add(wallValue);
            }
        }
        return Tuple.Create(wallCount, oneLineWalls);
    }
    
    private void BuildWalls() //Trump...
    {
        int i = 0;
        foreach (var line in wallLines)
        {
            int j = 0;
            foreach (var wall in line)
            {
                if (wall == 0)
                {
                    j++;
                    continue;
                }
                float xPos;
                switch (j)
                {
                    case 0:
                        xPos = wallXPos.left;
                        break;
                    case 1:
                        xPos = wallXPos.center;
                        break;
                    case 2:
                        xPos = wallXPos.right;
                        break;
                    default:
                        xPos = 0;
                        break;
                }
                Instantiate(wallPrefab, new Vector3(xPos, 0, (-17f + i * 9)), Quaternion.identity, gameObject.transform);
                j++;
            }
            i++;
        }
    }
}
