using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public Transform teleport;
    public GameObject playerTileMaps;

    public void Teleportation()
    {
         if (Input.GetKey(KeyCode.Mouse0))
        {
            gameObject.transform.position = teleport.transform.position;
            playerTileMaps.transform.position = teleport.transform.position;
            playerTileMaps.transform.position += new Vector3(0, 0.25f, 0);

        }
    }
    void Update()
    {
        
    }
}
