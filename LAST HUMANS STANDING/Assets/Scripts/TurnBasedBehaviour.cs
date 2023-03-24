using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedBehaviour : MonoBehaviour
{
    public int initiative;
    protected virtual void OnEnable()
    {
        TurnManager.instance.turners.Add(this);
    }
    protected virtual void OnDisable()
    {
        TurnManager.instance.turners.Remove(this);
    }
    public bool isMyturn;
    public virtual void BeginTurn() {
        isMyturn = true;
    }
    public virtual void EndTurn() {
        isMyturn = false;
        TurnManager.instance.NextTurn(this);
    }
}
