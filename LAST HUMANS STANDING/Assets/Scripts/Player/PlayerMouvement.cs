using DG.Tweening;
using UnityEngine;

public class PlayerMouvement : TurnBasedBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] public UIManager uiManager;
    [SerializeField] public Transform teleport;
    [SerializeField] GameObject playerTileMaps;
    [SerializeField] GameObject playerTileMapKill;
    [SerializeField] public bool canMove;
    [SerializeField] public int deplacementPoint;

    private void Start()
    {
        teleport.transform.position = gameObject.transform.position;
        playerTileMaps.transform.position = teleport.transform.position;
        playerTileMaps.transform.position += new Vector3(0, 0.25f, 0);
        playerTileMapKill.transform.position = teleport.transform.position;
        playerTileMapKill.transform.position += new Vector3(0, 0.25f, 0);
    }
    public void DoStep()
    {
        if (deplacementPoint > 0)
        {
            gameObject.transform.DOMove(teleport.transform.position, 0.5f);
            playerTileMaps.transform.position = teleport.transform.position;
            playerTileMaps.transform.position += new Vector3(0, 0.25f, 0);
            playerTileMapKill.transform.position = teleport.transform.position;
            playerTileMapKill.transform.position += new Vector3(0, 0.25f, 0);
            deplacementPoint -= 1;
        }
        else
        {
            print("Déplacement impossible");
            EndTurn();//SOLUTION TEMPORAIRE
        }
    }

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
