using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;
    public static List<TurnBasedBehaviour> turners = new List<TurnBasedBehaviour>();
    public void Awake()
    {
        instance = this;
    }
    public void OnEnable()
    {
        instance = this;
    }
    public IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        OrderList();
        turners[0].BeginTurn();
    }
    public void OrderList()
    {
        turners = turners.OrderBy( (turn) => -turn.initiative).ToList();
    }
    public CameraController camUpdate;
    public void NextTurn(TurnBasedBehaviour turn)
    {
        int index = turners.IndexOf(turn) + 1;
        if(index >= turners.Count) index = 0;

        turners[index].BeginTurn();
        camUpdate.UpdateCam(turners[index]);   
    }
}
