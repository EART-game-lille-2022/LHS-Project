using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLife : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] AudioClip ZombieDamageClip;
    [SerializeField] int MaxHealth;
    public BattleSystem battleSystem;

    public int Health
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
        MaxHealth = 5;
        health = MaxHealth;
    }

    public int amount;
    public void Damage(int Amount)
    {
        health -= Amount;
        AudioManager.Instance.PlaySFX(ZombieDamageClip);
        Death();
    }

    public void Death()
    {
        if(health <= 0)
        {
            battleSystem.FinishFight();
            gameObject.SetActive(false);
            // Debug.Log("Death");
        }
    }
}
