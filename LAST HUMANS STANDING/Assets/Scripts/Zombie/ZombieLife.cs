using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLife : MonoBehaviour
{
    public static List<ZombieLife> zombies = new List<ZombieLife>();
    [SerializeField] int health;
    [SerializeField] AudioClip ZombieDamageClip;
    [SerializeField] int MaxHealth;
    public BattleSystem battleSystem;
    public bool dead = false; 
    public AudioClip zombieDeath;
    // float randomNumber;

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
    // public void Sound()
    // {
    //     print(randomNumber);
    // }

    void Start()
    {
        // randomNumber = Random.Range(0, 100);
        MaxHealth = 5;
        health = MaxHealth;
    }
    
    // private void Update() 
    // {
    //     Random();
    //     print(randomNumber);
    //     if(randomNumber == 1)
    //     {
    //         AudioManager.Instance.PlaySFX(zombieGrowl);
    //     }
    //     else if(randomNumber !=1)
    //     {
    //         print("no");
    //     }
    // }

    public int amount;
    public void Damage(int Amount)
    {
        health -= Amount;
        Debug.Log(name + " dmg " + Amount + " -> " + health);
        if(health <= 0)
        Death();
        // AudioManager.Instance.PlaySFX(ZombieDamageClip);
    }

    public void Death()
    {
        if(health <= 0)
        {
            dead = true;
            // battleSystem.FinishFight();
             gameObject.SetActive(false);
            // Destroy(gameObject);
            Debug.Log("Death");
            battleSystem.DeathManager();
            AudioManager.Instance.PlaySFX(zombieDeath);
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
