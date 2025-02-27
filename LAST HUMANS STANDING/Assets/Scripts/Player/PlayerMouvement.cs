using DG.Tweening;
using UnityEngine;

public class PlayerMouvement : TurnBasedBehaviour
{
    public Transform teleport;
    public GameObject playerTileMaps;
    public GameObject playerTileMapKill;
    public bool canMove;
    public int deplacementPoint;

    private void Start()
    {
       teleport.transform.position = gameObject.transform.position;
        playerTileMaps.transform.position = teleport.transform.position;
        playerTileMaps.transform.position += new Vector3(0, 0.25f, 0);
        playerTileMapKill.transform.position = teleport.transform.position;
        playerTileMapKill.transform.position += new Vector3(0, 0.25f, 0);
    }
    public void Teleportation()
    {
        if (deplacementPoint > 0)
        {
            gameObject.transform.DOMove(teleport.transform.position,0.5f);
            playerTileMaps.transform.position = teleport.transform.position;
            playerTileMaps.transform.position += new Vector3(0, 0.25f, 0);
            playerTileMapKill.transform.position = teleport.transform.position;
            playerTileMapKill.transform.position += new Vector3(0, 0.25f, 0);
            deplacementPoint -= 1;
        }
        else
        {
            print("Déplacement impossible");
            EndTurn();
        }
    }
    public GameObject canvas;
    public override void BeginTurn()
    {
        deplacementPoint = 2;
        base.BeginTurn();
        Debug.Log("it s my turn : " + name);
        print(deplacementPoint);
        // if(Distance > 5)
        // Invoke("EndTurn", 3);
        // else  PlayerAttack()

        if (canvas != null) canvas.SetActive(true);
    }

    public override void EndTurn()
    {
        base.EndTurn();
        if (canvas != null) canvas.SetActive(false);
    }
}
