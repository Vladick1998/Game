using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[System.Serializable]
public class Tile : GameMap
{
    [SerializeField]
    TileBase FloorTile;
    //[SerializeField]
    //ileBase WallTile;
    [SerializeField]
    GameObject Floor;
    //[SerializeField]
    //GameObject Wall;
    Tilemap FloorTileMap;
    [SerializeField]
    Wall[] walls;
    [SerializeField]
    public List<Tile> nTile;
    //Vector3Int leftdown;
    //Vector3Int rightdown;
    //Vector3Int lefttop;
    //Vector3Int righttop;
    // Start is called before the first frame update
    void Start()
    {
        //if (transform.position == new Vector3(0,0,0))
        //{
        //    Debug.Log("rodipiT");
        //}
        //Debug.Log("floor pos="+transform.position);
        FloorTileMap = Floor.GetComponent<Tilemap>();
        Floor.transform.localPosition=new Vector3(HorLenght/2*-1,VerLenght/2*-1,0);
        //leftdown = new Vector3Int(0, 0, 0);
        //lefttop = new Vector3Int(0, VerLenght, 0);
        //rightdown = new Vector3Int(HorLenght, 0, 0);
        //righttop = new Vector3Int(HorLenght, VerLenght, 0);
        Vector3Int pos = new Vector3Int(0, 0, 0);
        FloorTileMap.ClearAllTiles();
        for (int i = 0; i < HorLenght; i++)
        {
            pos.x = i;
            for (int q = 0; q < VerLenght; q++)
            {
                pos.y = q;
                FloorTileMap.SetTile(pos, FloorTile);
            }
        }
        walls[0].WallType = 2;
        //walls[0].;
        //for (int i = 0; i < ; i++)
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
