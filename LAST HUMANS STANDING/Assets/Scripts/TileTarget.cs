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

    public GameObject Zombie;
    private TilemapCollider2D tileCollider;
    private CapsuleCollider2D zombieCollider;

    public void DoUpdate() 
    {
        if (!playerMvt.isMyturn) return;

        Vector3 v = cam.ScreenToWorldPoint(Input.mousePosition);
        v.z = 0;
        transform.position = v;

        cellPosDebug = tilemapDebug.WorldToCell(v);
        cellPosPortee = tilemapPortee.WorldToCell(v);
        cellPosKill = tilemapKill.WorldToCell(v);
        // cellPosGun = tilemapGun.WorldToCell(v);

        transform.position = tilemapDebug.CellToWorld(cellPosDebug)+new Vector3(0, 0.25f, 0);
        tileDebug = tilemapDebug.GetTile(cellPosDebug);
        tilePortee = tilemapPortee.GetTile(cellPosPortee);
        tileKill = tilemapKill.GetTile(cellPosKill);
        // tileGun = tilemapGun.GetTile(cellPosGun);
        Verification();
        Attackable();
    }

    void Verification()
    {
        if (tileDebug != null) Debug.Log("Do update : " + tileDebug.name);
        if (tileDebug == null || tileDebug.name.Contains("wall")) return;
        // if (tileDebug != null||tileDebug.ToString() != null || tileDebug.ToString().Contains("ground")) 
        // {
                playerMvt.Teleportation();
        // }
    }

    void Attackable()
    { 
        if (Input.GetKey(KeyCode.Mouse1))
        {

            /*lifeZ.Damage(lifeZ.amount);
            Debug.Log("damage");*/
            foreach(var z in ZombieLife.zombies)
            {
                Vector2 lp = z.transform.position - transform.position;
                if(lp.magnitude < .5f) {
                    z.Damage(z.amount);
                    return;
                }
            }
        }
    }
    /*public bool ZombieInZone = false;
    public void OnTriggerStay2D(Collider2D other)
    {
        print("ta");
        if(other.CompareTag("Ennemy"))
        {
            ZombieInZone = true;
        }
    }*/
    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if(zombieCollider == other)
    //     {
    //         ZombieInZone = false;
    //     }
    // }
}

