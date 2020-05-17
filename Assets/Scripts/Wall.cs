using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Wall : Tile
{
    // Start is called before the first frame update
    [SerializeField]
    Tilemap tileMap;
    [SerializeField]
    TileBase[] tl;
    [SerializeField]
    private int wallType;
    public int WallType
    {
        get
        {
            return wallType;
        }
        set
        {
            wallType = value;
            WallGenerator(wallType);
        }

    }
    enum wall
    {
        solid,
        door,
        none
    }
    /*wallGe
     * 
     */
    void Start()
    {
        //wallType = 0;

        switch (gameObject.name)
        {
            case "Top":
                this.transform.localPosition = new Vector3(0, HorLenght / 2 + 0.5f);
                break;
            case "Right":
                this.transform.localPosition = new Vector3(HorLenght / 2 + 0.5f, 0);
                break;
            case "Down":
                this.transform.localPosition = new Vector3(0, (HorLenght / 2 + 0.5f) * -1);
                break;
            case "Left":
                this.transform.localPosition = new Vector3((HorLenght / 2 + 0.5f) * -1, 0);
                break;
            default:
                Debug.Log("lost wall - " + name);
                break;
        }

        WallGenerator(wallType);
    }
    void WallGenerator(int wallType)
    {
        if (tileMap == null)
        {
            tileMap = gameObject.GetComponent<Tilemap>();
        }
        switch (wallType)
        {
            case 0:
                for (int i = HorLenght * -1; i < HorLenght; i++)
                {
                    tileMap.SetTile(new Vector3Int(i, 0, 0), tl[0]);
                }
                tileMap.SetTile(new Vector3Int(HorLenght, 0, 0), tl[1]);
                break;
            case 1:
                for (int i = HorLenght * -1; i < HorLenght; i++)
                {
                    if (i == 1 || i == 0 || i == -1 || i == -2)
                    {
                        //Debug.Log("vse ploxo");
                    }
                    else
                    {
                        tileMap.SetTile(new Vector3Int(i, 0, 0), tl[0]);
                    }
                }
                tileMap.SetTile(new Vector3Int(HorLenght, 0, 0), tl[1]);
                break;
            case 2:
                tileMap.SetTile(new Vector3Int(HorLenght, 0, 0), tl[1]);
                break;
            default:
                Debug.Log("wall bug");
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
