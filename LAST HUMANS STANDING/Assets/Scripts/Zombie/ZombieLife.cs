using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieLife : MonoBehaviour
{
    public static List<ZombieLife> zombies = new List<ZombieLife>();
    [SerializeField] float maxHealth;
    [SerializeField] float health;
    [SerializeField] Image LifeBar;
    [SerializeField] AudioClip ZombieDamageClip;
    public BattleSystem battleSystem;
    public bool dead = false;

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    void Start()
    {
        health = maxHealth;
    }

    public void Damage(int Amount)
    {
        health -= Amount;
        Debug.Log(name + " dmg " + Amount + " -> " + health);
        LifeBar.DOFillAmount(health / maxHealth, 0.5f);
        if (health <= 0)
            Death();
        //AudioManager.Instance.PlaySFX(ZombieDamageClip);
    }

    public void Death()
    {
        if (health <= 0)
        {
            dead = true;
            gameObject.SetActive(false);
            Debug.Log("Death");
            battleSystem.DeathManager();


        }
    }

    private void OnEnable()
    {
        zombies.Add(this);
    }
    private void OnDisable()
    {
        zombies.Remove(this);
    }
}
