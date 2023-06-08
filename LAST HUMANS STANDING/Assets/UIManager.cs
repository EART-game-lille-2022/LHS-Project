using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject smartphone;
    [SerializeField] List<GameObject> lifePointGameObject;
    [SerializeField] List<GameObject> energyPointGameObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PointShow(bool active,GameObject icon)
    {
        if (active)
        {
            icon.SetActive(true);
        }
    }

    void SlideIn(bool active) 
    {
        if (active)
        {
            smartphone.transform.DOMoveX(target);
        }
    }
}
