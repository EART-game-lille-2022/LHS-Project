using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public Transform teleport;

    void Teleportation()
    {
         if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            gameObject.transform.position = teleport.transform.position;
        }
    }
    void Update()
    {
        Teleportation();
    }
}
