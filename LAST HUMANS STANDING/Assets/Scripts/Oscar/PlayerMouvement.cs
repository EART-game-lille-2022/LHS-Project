using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : TurnBasedBehaviour
{
    public Transform teleport;
    public GameObject playerTileMaps;
    public GameObject playerTileMapKill;

    public void Teleportation()
    {
         if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gameObject.transform.position = teleport.transform.position;
            playerTileMaps.transform.position = teleport.transform.position;
            playerTileMaps.transform.position += new Vector3(0, 0.25f, 0);
            playerTileMapKill.transform.position = teleport.transform.position;
            playerTileMapKill.transform.position += new Vector3(0, 0.25f, 0);

        }
    }
    void Update()
    {
        
    }
    public GameObject canvas;
    public override void BeginTurn()
    {
        base.BeginTurn();
        Debug.Log("it s my turn : " + name);
        // if(Distance > 5)
        // Invoke("EndTurn", 3);
        // else  PlayerAttack()

        if(canvas!= null) canvas.SetActive(true);
    }

    public override void EndTurn()
    {
        base.EndTurn();
        if (canvas != null) canvas.SetActive(false);
    }
}
