using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : TurnBasedBehaviour
{
    public BattleSystem battleSystem;
    public Collider2D col2D;
    public bool inFight;
    List<OnDisableBehaviour> onDisableBehaviours = new List<OnDisableBehaviour>();
    public AudioClip zombieGrowl;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(collision.gameObject + " " + collision.gameObject.tag);
        
        if (!inFight && collision.gameObject.CompareTag("Player") )
        {
            battleSystem.Encounter();
            inFight = true;
            // OnDisableBehaviour o = collision.gameObject.AddComponent<OnDisableBehaviour>();
            // onDisableBehaviours.Add( o );
            // o.onDisable.AddListener(OnTargetDisabled);
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        // OnTargetDisabled(collision.GetComponent<OnDisableBehaviour>());
        if (collision.gameObject.CompareTag("Player"))
            inFight = false;
    }

    void OnTargetDisabled(OnDisableBehaviour b)
    {
        if(onDisableBehaviours.Contains(b))
        {
            onDisableBehaviours.Remove(b);
            Destroy(b);
            inFight = false;
        }
    }

    public override void BeginTurn()
    {
        // CameraController switchCam = GetComponent<CameraController>();
        base.BeginTurn();
        AudioManager.Instance.PlaySFX(zombieGrowl);
        Debug.Log("it s my turn : " + name);

        // switchCam.Update();

        // if(Distance > 5)
            Invoke("EndTurn", 3);
        // else  PlayerAttack()
    }
    
}
