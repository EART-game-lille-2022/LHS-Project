using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileTarget : MonoBehaviour
{
    public float Dirx = 0f;public float Diry = 0f;public float Dirz = 0f;
    public Camera cam;
    public Tilemap tilemapPortee, tilemapDebug;

    public Vector3Int cellPosPortee, cellPosDebug;

    public TileBase tilePortee, tileDebug;

    public Direction sampleDir;
    public Direction[] ennemyPattern;
    public PlayerMouvement playerMvt;

    void Update() {
        Vector3 v = cam.ScreenToWorldPoint( Input.mousePosition );
        v.z = 0;
        // transform.position = v;

        cellPosDebug = tilemapDebug.WorldToCell(v);
        cellPosPortee = tilemapPortee.WorldToCell(v);

        transform.position = tilemapDebug.CellToWorld(cellPosDebug)+new Vector3(Dirx,Diry,Dirz);
        tileDebug = tilemapDebug.GetTile(cellPosDebug);
        tilePortee = tilemapPortee.GetTile(cellPosPortee);
        Verification();
        // if(tileOn != null )
        // {
        //     Debug.Log(tileOn.name.Contains("block"));
        // }
        // tileForward= tilemap.GetTile(cellPos);
    }
    void Verification()
    {
        if (tileDebug != null||tileDebug.ToString() != null || tileDebug.ToString().Contains("ground")) ; 
        {
            if (tilePortee!= null || tilePortee.ToString() != null)
            {
                playerMvt.Teleportation();
            }
        }
    }
}

