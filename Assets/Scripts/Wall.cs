using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Wall : Tile
{
    // Start is called before the first frame update
    [SerializeField]
    TileBase tile;
    void Start()
    {
        
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
