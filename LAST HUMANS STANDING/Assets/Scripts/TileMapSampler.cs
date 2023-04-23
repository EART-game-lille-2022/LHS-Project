using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.Tilemaps;


[ExecuteAlways]
public class TileMapSampler : MonoBehaviour
{
    public enum Direction
    {
        Up = 0, 
        Down = 2,
        Left = 3,
        Right = 1
    }
    public static Vector2 LeftUp = new Vector2(-1, .72f); // forward
    public static Vector2 Leftdown = new Vector2(-1, .72f); // forward
    public static Vector2 RightUp = new Vector2(-1, .72f); // forward
    public static Vector2 RightDown = new Vector2(-1, .72f); // forward

    public static Vector2[] directions = new Vector2[] 
    {
        LeftUp, RightUp, RightDown, Leftdown
    };

    public static Vector3Int[] directionsCell = new Vector3Int[] 
    {
        new Vector3Int(0, 1, 0), new Vector3Int(0, 1, 0), new Vector3Int(0, 1, 0), new Vector3Int(0, 1, 0)
    };

    public static Vector2 GetDirection(Direction d)
    {
        return directions[(int)d];
    }

    public static Vector3Int GetCellDirection(Direction d)
    {
        return directionsCell[(int)d];
    }

    public Tilemap tilemap;
    public Vector3Int cellPos;
    public TileBase tileOn, tileForward;

    public Direction sampleDir;
    public Direction[] ennemyPattern;

    void Update() 
    {
        cellPos = tilemap.WorldToCell(transform.position);
        tileOn = tilemap.GetTile(cellPos);
        if(tileOn != null )
        {
            Debug.Log(tileOn.name.Contains("block"));
        }
        tileForward= tilemap.GetTile(cellPos + GetCellDirection(sampleDir) );
    }
}

