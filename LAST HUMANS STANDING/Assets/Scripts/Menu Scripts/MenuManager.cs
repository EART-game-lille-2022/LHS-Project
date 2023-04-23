using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public List<MenuData> Level = new ();
    public List<Button> buttons = new (); 
    public Button continueButton;
    public GameObject chooseLevelMenu;
    public List <GameObject> chooseLevelMenuTargets = new ();

    private void Start()
    {
        if (Level[0].finished)continueButton.interactable = true;
        else continueButton.interactable = false;
    }
    public void NewGame()
    {
        foreach (MenuData data in Level)
        {
            data.finished = false;
            data.unlocked = false;
            SceneManager.LoadScene(1);
        }
    }
    public void Continue()
    {
        for(int i = 0; i < Level.Count;i++)
        {
            if (Level[i].finished!)
            {
                SceneManager.LoadScene(i - 1);
            }
        }
    }
    public void ChooseLvl(bool open)
    {
        StopAllCoroutines();
        StartCoroutine(MenuSlider(open));
    }
    IEnumerator MenuSlider(bool open) 
    { 
        if (open)
        {
            checkLevels();
            chooseLevelMenu.transform.DOMoveX(chooseLevelMenuTargets[0].transform.position.x, 1);
            
        }
        else
            chooseLevelMenu.transform.DOMoveX(chooseLevelMenuTargets[1].transform.position.x, 0.5f);
        yield return null; 
    }
    public void checkLevels()
    {
        for (int i = 0; i < Level.Count; i++)
        {
            if (Level[i].finished)

            if (Level[i].unlocked)
            {
                buttons[i].interactable = true;
            }
            else buttons[i].interactable = false;
        }
    }

    public void LaunchLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

}
