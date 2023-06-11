using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//OUAH
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject smartphone;
    [SerializeField] List<GameObject> lifePointGameObject;
    [SerializeField] List<GameObject> energyPointGameObject;
    [SerializeField] List<GameObject> target;

    public void PointShow(bool active,GameObject icon)
    {
        if (active)
        {
            icon.SetActive(true);
        }
        else
        {
            icon.SetActive(false);
        }
    }

    public void SlideIn(bool active) 
    {
        if (active)
        {
            smartphone.transform.DOMove(target[1].transform.position,0.5f);
        }
        else
            smartphone.transform.DOMove(target[0].transform.position, 0.5f);
    }
}
