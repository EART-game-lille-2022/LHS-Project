using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileTarget : MonoBehaviour
{
    public float Dirx = 0f;public float Diry = 0f;public float Dirz = 0f;
    public Camera cam;
    public Tilemap tilemap;
    public Vector3Int cellPos;
    public TileBase tileOn, tileForward;

    public Direction sampleDir;
    public Direction[] ennemyPattern;

    void Update() {
        Vector3 v = cam.ScreenToWorldPoint( Input.mousePosition );
        v.z = 0;
        // transform.position = v;

        cellPos = tilemap.WorldToCell(v);

        transform.position = tilemap.CellToWorld(cellPos)+new Vector3(Dirx,Diry,Dirz);
        tileOn = tilemap.GetTile(cellPos);
        if(tileOn != null )
        {
            Debug.Log(tileOn.name.Contains("block"));
        }
        // tileForward= tilemap.GetTile(cellPos);
    }
}

