using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ZombieBehaviour : TurnBasedBehaviour
{
    public Tilemap debugTilemap;
    public BattleSystem battleSystem;
    public Collider2D col2D;
    public bool inFight;
    public GameObject Target;
    List<OnDisableBehaviour> onDisableBehaviours = new List<OnDisableBehaviour>();
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(collision.gameObject + " " + collision.gameObject.tag);

        if (!inFight && collision.gameObject.CompareTag("Player"))
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
        if (onDisableBehaviours.Contains(b))
        {
            onDisableBehaviours.Remove(b);
            Destroy(b);
            inFight = false;
        }
    }

    public override void BeginTurn()
    {
        base.BeginTurn();
        Debug.Log("it s my turn : " + name);
        Vector3 Zpos = debugTilemap.WorldToCell(transform.position);
        Vector3 Tpos = debugTilemap.WorldToCell(Target.transform.position);
        if (Zpos.x < Tpos.x)
            Go("North");
        else if (Zpos.x > Tpos.x)
            Go("South");
        else if (Zpos.x == Tpos.x)
        {
            if (Zpos.y < Tpos.y)
                Go("West");
            else if (Zpos.y > Tpos.y)
                Go("East");
        }

        Invoke("EndTurn", 3);
    }
    void Go(string dir)
    {
        switch (dir)
        {
            case "North":
                transform.DOMove(transform.position + new Vector3(+0.5f, +0.25f, +0f), 0.5f);
                break;
            case "South":
                transform.DOMove(transform.position + new Vector3(-0.5f, -0.25f, +0f), 0.5f);
                break;
            case "East":
                transform.DOMove(transform.position + new Vector3(+0.5f, -0.25f, +0f), 0.5f);
                break;
            case "West":
                transform.DOMove(transform.position + new Vector3(-0.5f, +0.25f, +0f), 0.5f);
                break;
            default:
                break;
        }
    }
}
