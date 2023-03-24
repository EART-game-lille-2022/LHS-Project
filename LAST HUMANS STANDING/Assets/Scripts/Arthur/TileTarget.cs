using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileTarget : MonoBehaviour
{
    public Camera cam;
    public Tilemap tilemapPortee, tilemapDebug, tilemapKill;
    public Vector3Int cellPosPortee, cellPosDebug, cellPosKill;
    public TileBase tilePortee, tileDebug, tileKill;
    public Direction sampleDir;
    public Direction[] ennemyPattern;
    public PlayerMouvement playerMvt;
    public ZombieLife lifeZ;
    public GameObject Zombie;
    private TilemapCollider2D tileCollider;
    private CapsuleCollider2D zombieCollider;

    void Update() {
        Vector3 v = cam.ScreenToWorldPoint(Input.mousePosition);
        v.z = 0;
        // transform.position = v;

        cellPosDebug = tilemapDebug.WorldToCell(v);
        cellPosPortee = tilemapPortee.WorldToCell(v);
        cellPosKill = tilemapKill.WorldToCell(v);

        transform.position = tilemapDebug.CellToWorld(cellPosDebug)+new Vector3(0, 0.25f, 0);
        tileDebug = tilemapDebug.GetTile(cellPosDebug);
        tilePortee = tilemapPortee.GetTile(cellPosPortee);
        tileKill = tilemapKill.GetTile(cellPosKill);
        Verification();
        Attackable();
        lifeZ.Death();
        // if(tileOn != null )
        // {
        //     Debug.Log(tileOn.name.Contains("block"));
        // }
        // tileForward= tilemap.GetTile(cellPos);
    }
    void Verification()
    {
        // if (tileDebug != null||tileDebug.ToString() != null || tileDebug.ToString().Contains("ground")) 
        // {
            if (tilePortee!= null || tilePortee.ToString() != null)
            {
                playerMvt.Teleportation();
            }
        // }
    }
    void Attackable()
    { 
        if (Input.GetKey(KeyCode.Mouse1) && ZombieInZone)
        {
            lifeZ.Damage(lifeZ.amount);
            Debug.Log("damage");
        }
    }
    public bool ZombieInZone = false;
    public void OnTriggerStay2D(Collider2D other)
    {
        print("ta");
        if(other.CompareTag("Ennemy"))
        {
            ZombieInZone = true;
        }
    }
    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if(zombieCollider == other)
    //     {
    //         ZombieInZone = false;
    //     }
    // }
}

