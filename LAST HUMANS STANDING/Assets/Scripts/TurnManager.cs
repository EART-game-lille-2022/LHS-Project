using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;
    public List<TurnBasedBehaviour> turners;
    public void OnEnable()
    {
        instance = this;
    }
    public void Start()
    {
        OrderList();
        turners[0].BeginTurn();
    }
    public void OrderList()
    {
        turners = turners.OrderBy( (turn) => -turn.initiative).ToList();
    }
    public void NextTurn(TurnBasedBehaviour turn)
    {
        int index = turners.IndexOf(turn) + 1;
        if(index >= turners.Count) index = 0;

        turners[index].BeginTurn();
    }
}
