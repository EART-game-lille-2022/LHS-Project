using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;
public class playerattack : MonoBehaviour
{
    public Tilemap tileMapKill;
    public Vector3Int cellPosKill;
    public TileBase tileKill;
    public Camera cam;
    
    void Update()
    {
        Vector3 v = cam.ScreenToWorldPoint( Input.mousePosition );
        v.z = 0;
        cellPosKill =tileMapKill.WorldToCell(v);
    }
    void Killable()
    {

    }
}
