using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EntityXPos
{
    public static float left = -1.7f;
    public static float center = 0f;
    public static float right = 1.7f;
}


public class ObstacleGenerator : MonoBehaviour
{
    public bool isTutorial = false;
    public GameObject wallPrefab;
    public GameObject boostItemPrefab;
    private List<List<int>> wallLines = new List<List<int>>(); 
    private List<List<int>> itemsLines = new List<List<int>>(); 

    void Start()
    {
        if (!isTutorial)
        {
            BuildWallsMap();
            BuildItemsMap();    
        }
        else
        {
            Instantiate(wallPrefab, new Vector3(0f, 0, (-17f + 9f)), Quaternion.identity, gameObject.transform);
            Instantiate(boostItemPrefab, new Vector3(0f, 0, (-17f + 18f)), Quaternion.identity, gameObject.transform);
        }
    }

    private Tuple<int, List<int>> SetUpWallLine(int wallCount, List<int> oneLineWalls)
    {
        for (int j = 0; j < 3; j++)
        {
            int wallValue = (int)Mathf.Round(UnityEngine.Random.Range(0f, 1f));
            if (wallValue == 1 && wallCount < 2)
            {
                wallCount += 1;
                oneLineWalls.Add(wallValue);
            }
            else
            {
                oneLineWalls.Add(0);
            }
        }
        return Tuple.Create(wallCount, oneLineWalls);
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

    private List<int> SetUpItemLine(List<int> oneLineItems)
    {
        int itemCount = 0;
        for (int j = 0; j < 3; j++)
        {
            int itemValue = (int)Mathf.Round(UnityEngine.Random.Range(0f, 4f));
            if (itemValue == 1 && itemCount == 0)
            {
                Debug.Log(itemValue);
                itemCount++;
                oneLineItems.Add(1);
            }
            else
            {
                oneLineItems.Add(0);
            }
        }
        return oneLineItems;
    }

    private void SetUpItems()
    {
        for (int i = 0; i < 6; i++)
        {
            List<int> oneLineItems = new List<int>();
            oneLineItems = SetUpItemLine(oneLineItems);
            itemsLines.Add(oneLineItems);
        }
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
                        xPos = EntityXPos.left;
                        break;
                    case 1:
                        xPos = EntityXPos.center;
                        break;
                    case 2:
                        xPos = EntityXPos.right;
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

    private void BuildItems()
    {
        int i = 0;
        foreach (var line in itemsLines)
        {
            if (UnityEngine.Random.Range(0f, 1f) == 0) continue;
            int j = 0;
            foreach (var item in line)
            {
                if (item == 0)
                {
                    j++;
                    continue;
                }
                float xPos;
                switch (j)
                {
                    case 0:
                        xPos = EntityXPos.left;
                        break;
                    case 1:
                        xPos = EntityXPos.center;
                        break;
                    case 2:
                        xPos = EntityXPos.right;
                        break;
                    default:
                        xPos = 0;
                        break;
                }
                Instantiate(boostItemPrefab, new Vector3(xPos, 0, (-17 + (i * 9) + 4.5f)), Quaternion.identity, gameObject.transform);
                j++;
            }
            i++;
        }
    }

    private void BuildWallsMap()
    {
        SetUpWalls();
        BuildWalls();
    }

    private void BuildItemsMap()
    {
        SetUpItems();
        BuildItems();
    }
}
