using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : TurnBasedBehaviour
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

    public override void BeginTurn()
    {
        base.BeginTurn();
        Debug.Log("it s my turn : " + name);
        // if(Distance > 5)
            Invoke("EndTurn", 3);
        // else  PlayerAttack()
    }
}
