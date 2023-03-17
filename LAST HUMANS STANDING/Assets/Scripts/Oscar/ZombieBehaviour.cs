using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    public BattleSystem battleSystem;
    public Collider2D col2D;
    public bool inFight;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(!inFight)
            battleSystem.Encounter();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        inFight = false;
    }
}
