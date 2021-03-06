﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameMap : MonoBehaviour
{
    [SerializeField]
    public static int HorLenght = 16;

    [SerializeField]
    public static int VerLenght = 16;

    [SerializeField]
    private int maxRooms;

    [SerializeField]
    private GameObject[] tile;

    [SerializeField]
    private int mapVerLenght;

    [SerializeField]
    private int mapHorLenght;

    [SerializeField]
    private List<Vector3> pos;

    [SerializeField]
    public GameObject[,] gameMap;

    [SerializeField]
    private List<Vector3> wallDots;

    #region
    //[SerializeField]
    //Tilemap Floor;
    //[SerializeField]
    //TileBase FloorTile;
    //[SerializeField]
    //Tilemap Wall;
    //[SerializeField]
    //TileBase WallTile;
    //Vector3Int leftdown;
    //Vector3Int rightdown;
    //Vector3Int lefttop;
    //Vector3Int righttop;
    /* 0 = пустота
     * 1 = старт
     * 2 = комната
     * 3 = лут или нпс
     * 4 = босс
     */
    #endregion
    private void Awake()
    {

    }
    public void GenerateMap()
    {
        #region переменные
        if (mapHorLenght + mapVerLenght < maxRooms / 2)
        {
            mapVerLenght = maxRooms / 2;
            mapHorLenght = maxRooms / 2;
        }
        if (maxRooms < 1)
        {
            maxRooms = 10;
        }
        tile = new GameObject[maxRooms];
        if (HorLenght < 4 || VerLenght < 4)
        {
            HorLenght = 16;
            VerLenght = 16;
        }
        gameMap = new GameObject[mapHorLenght, mapVerLenght];
        #region old
        //leftdown = new Vector3Int(0, 0, 0);
        //lefttop = new Vector3Int(0, 15, 0);
        //rightdown = new Vector3Int(15, 0, 0);
        //righttop = new Vector3Int(15, 15, 0);
        //if (Floor==null)
        //{
        //    Floor = new Tilemap();
        //}

        //Vector3Int pos = new Vector3Int(0, 0, 0);
        //Floor.ClearAllTiles();
        //Wall.ClearAllTiles();
        //for (int i = 1; i < 15; i++)
        //{
        //    pos.x = i;
        //    for (int q = 1; q < 15; q++)
        //    {
        //        pos.y = q;
        //        Floor.SetTile(pos,FloorTile);
        //    }
        //}
        //for (int i = 0; i < 15; i++)
        //{
        //    Wall.SetTile(leftdown, WallTile);
        //    Wall.SetTile(lefttop, WallTile);
        //    Wall.SetTile(righttop, WallTile);
        //    Wall.SetTile(rightdown, WallTile);
        //    leftdown.y++;
        //    lefttop.x++;
        //    righttop.y--;
        //    rightdown.x--;
        //}
        #endregion
        pos = new List<Vector3>();
        wallDots = new List<Vector3>();
        pos.Add(new Vector3(0, 0));
        List<Vector3> busyPos = new List<Vector3>();
        var Parent = gameObject.transform.Find("Tiles");
        #endregion
        for (int i = 0; i < maxRooms; i++)
        {
            int rand = Random.Range(0, pos.Count - 1);

            tile[i] = Instantiate(Resources.Load<GameObject>("Prefabs/Tile"), pos[rand], Quaternion.identity, Parent);
            gameMap[Convert.ToInt32((pos[rand].y / (VerLenght + 1)) + (mapVerLenght / 2)), (Convert.ToInt32(pos[rand].x / (HorLenght + 1)) + (mapHorLenght / 2))] = tile[i];
            Debug.Log("x="+(Convert.ToInt32(pos[rand].x / (HorLenght + 1)) + (mapHorLenght / 2))+ "y="+Convert.ToInt32((pos[rand].y / (VerLenght + 1)) + (mapVerLenght / 2)));
            #region if pos
            if (!pos.Contains(pos[rand] + new Vector3(HorLenght + 1, 0)))
            {
                if (!busyPos.Contains(pos[rand] + new Vector3(HorLenght + 1, 0)))
                {
                    pos.Add(pos[rand] + new Vector3(HorLenght + 1, 0));
                }
                else
                {
                    //tile[i].GetComponent<Tile>().nTile.Add(new Tile());

                }
            }
            if (!pos.Contains(pos[rand] + new Vector3(0, VerLenght + 1)) && !busyPos.Contains(pos[rand] + new Vector3(0, VerLenght + 1)))
            {
                pos.Add(pos[rand] + new Vector3(0, VerLenght + 1));
            }
            if (!pos.Contains(pos[rand] + new Vector3((HorLenght + 1) * -1, 0)) && !busyPos.Contains(pos[rand] + new Vector3((HorLenght + 1) * -1, 0)))
            {
                pos.Add(pos[rand] + new Vector3((HorLenght + 1) * -1, 0));
            }
            if (!pos.Contains(pos[rand] + new Vector3(0, (VerLenght + 1) * -1)) && !busyPos.Contains(pos[rand] + new Vector3(0, (VerLenght + 1) * -1)))
            {
                pos.Add(pos[rand] + new Vector3(0, (VerLenght + 1) * -1));
            }
            busyPos.Add(pos[rand]);
            #endregion
            pos.RemoveAt(rand);
        }

    }
    public void GenerateRooms()
    {

    }
    private void Start()
    {
        GenerateMap();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            for (int i = 0; i < tile.Length; i++)
            {
                Destroy(tile[i]);
            }
            GenerateMap();
        }
        #region map generator
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    Vector3 vc = new Vector3();
        //    Debug.ClearDeveloperConsole();
        //    for (int x = 0; x < gameMap.GetLength(0); x++)
        //    {
        //        vc.x += 17;
        //        vc.y = 0;
        //        string tmp = "";
        //        for (int y = 0; y < gameMap.GetLength(1); y++)
        //        {
        //            vc.y += 17;
        //            if (gameMap[y, x] != null)
        //            {
        //                Instantiate(Resources.Load<GameObject>("Prefabs/Tile"), vc, Quaternion.identity, gameObject.transform);
        //            }
        //     }
        //    Debug.Log(tmp);
        //}}
        #endregion
    }
}
