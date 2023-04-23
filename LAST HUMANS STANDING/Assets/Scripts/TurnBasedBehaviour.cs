using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TurnBasedBehaviour : MonoBehaviour
{
    public int Znumber;
    public int initiative;
    private int count;
    protected virtual void OnEnable()
    {
        TurnManager.turners.Add(this);
    }
    protected virtual void OnDisable()
    {
        TurnManager.turners.Remove(this);
    }
    public bool isMyturn;
    public virtual void BeginTurn() 
    {
        foreach (var turner in TurnManager.turners)
        {
            if (turner.tag== "Ennemy")
            {
                turner.gameObject.GetComponent<ZombieLife>().dead = true;
                if (count == Znumber) SceneManager.LoadScene("0");
                    
            }
        }
        isMyturn = true;
    }
    public virtual void EndTurn() 
    {
        isMyturn = false;
        TurnManager.instance.NextTurn(this);
    }
}
