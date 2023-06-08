using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BattleState { NOFIGHT, STARTFIGHT, PLAYERTURN, ENNEMYTURN, NEWENNEMI, WIN, LOOSE }
public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    public GameObject tilemapPortee;
    public GameObject tilemapvisee;
    public GameObject actionButton;
    public GameObject endTurnButton;
    public TextMeshProUGUI textTMP;
    public GameObject textGO;
    public bool activated = false;
    [SerializeField] int ZNumber;
    public AudioClip finishFight;


    private void Start()
    {
        state = BattleState.NOFIGHT;
        tilemapPortee.SetActive(true);
        tilemapvisee.SetActive(false);
        actionButton.SetActive(false);
        endTurnButton.SetActive(false);
        textGO.SetActive(false);



    }

    public void Encounter()
    {
        state = BattleState.STARTFIGHT;
        StartCoroutine(StartFight());

    }

    IEnumerator StartFight()
    {
        textGO.SetActive(true);
        textTMP.text = "un zombie vous a rep�r�!";
        yield return new WaitForSeconds(1);
        textTMP.text = "tuez le !";
        yield return new WaitForSeconds(1);
        textGO.SetActive(false);
        state = BattleState.PLAYERTURN;
        StartCoroutine(AnnoncePlayerTurn());

    }

    IEnumerator AnnoncePlayerTurn()
    {
        yield return new WaitForSeconds(1);
        textGO.SetActive(true);
        textTMP.text = "A vous de jouer...";
        actionButton.SetActive(true);
        endTurnButton.SetActive(true);
        tilemapPortee.SetActive(true);
        yield return new WaitForSeconds(0);

    }

    public void ChangeAction()
    {

        if (activated)
        {
            tilemapPortee.SetActive(true);
            tilemapvisee.SetActive(false);
            activated = false;
        }
        else
        {
            tilemapPortee.SetActive(false);
            tilemapvisee.SetActive(true);
            activated = true;
        }
    }

    public void EndOfTurn()
    {
        state = BattleState.ENNEMYTURN;
        state = BattleState.PLAYERTURN;
    }

    IEnumerator FinishFight()
    {
        state = BattleState.WIN;
        state = BattleState.NOFIGHT;
        tilemapPortee.SetActive(true);
        tilemapvisee.SetActive(false);
        actionButton.SetActive(false);
        //AudioManager.Instance.PlaySFX(finishFight);
        StartCoroutine(Message("Bien joue il n'y a plus d'ennemis"));
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
    public void DeathManager()
    {
        ZNumber--;
        if(ZNumber <=0)
        {
            StartCoroutine(FinishFight());
        }
    }

    IEnumerator Message(string message)
    {
        textGO.SetActive(true);
        textTMP.text = message;
        yield return new WaitForSeconds(1);
        textGO.SetActive(false);
    }



}
