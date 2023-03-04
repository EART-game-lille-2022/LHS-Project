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
    public Vector3Int cellPos;
    public TileBase tilePortee, tileSol;
    public Direction sampleDir;
    public Direction[] ennemyPattern;
    public PlayerMouvement playerMvt;

    void Update() {
        Verification();
        Vector3 v = cam.ScreenToWorldPoint( Input.mousePosition );
        v.z = 0;
        // transform.position = v;

        cellPos = tilemapDebug.WorldToCell(v);

        transform.position = tilemapDebug.CellToWorld(cellPos)+new Vector3(Dirx,Diry,Dirz);
        tileSol = tilemapDebug.GetTile(cellPos);
        tilePortee = tilemapPortee.GetTile(cellPos);
        // if(tileOn != null )
        // {
        //     Debug.Log(tileOn.name.Contains("block"));
        // }
        // tileForward= tilemap.GetTile(cellPos);
    }
    void Verification()
    {
        if(tilePortee != null)
        {
            if(tileSol.ToString().Contains("ground"));
            {
                playerMvt.Teleportation();
            }
        }
    }
}

