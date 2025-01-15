using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("Unit Characteristics")]
    [SerializeField] private string unitName;
    [SerializeField] private int health;
    [SerializeField] private ParticleSystem Heal;
    [SerializeField] private ParticleSystem Attack;
    [SerializeField] private ParticleSystem Barrier;
    [SerializeField] private ParticleSystem FireBall;
    [SerializeField] private ParticleSystem Cleansing;

    public Dictionary<string, Ability> Abilities { get; private set; }
    private int shieldAmount;
    private bool isBurning;

    public string Name => unitName;
    public int Health => health;

    [HideInInspector] public int MaxHealth;

    private void Awake()
    {
        MaxHealth = Health;
        Abilities = new Dictionary<string, Ability>
        {
            { "Attack", new Ability("Attack", damage: 8) },
            { "Barrier", new Ability("Barrier", shield: 5, duration: 2, cooldown: 4) },
            { "Regeneration", new Ability("Regeneration", heal: 2, duration: 3, cooldown: 5) },
            { "Fireball", new Ability("Fireball", damage: 5, duration: 5, cooldown: 6) },
            { "Cleansing", new Ability("Cleansing", cooldown: 5) }
        };
    }

    public void Initialize(string name, int initialHealth)
    {
        unitName = name;
        health = initialHealth;
    }

    public void TakeDamage(int damage)
    {
        Attack.Play();
        if (shieldAmount > 0)
        {
            shieldAmount -= damage;
            if (shieldAmount < 0)
            {
                health += shieldAmount; // subtract the excess damage from health
                shieldAmount = 0;
            }
        }
        else
        {
            health -= damage;
            if (health < 0) health = 0;
        }
    }

    public void ApplyShield(int amount, int duration)
    {
        Barrier.Play();
        shieldAmount += amount;
        StartCoroutine(ShieldDuration(duration));
    }

    private IEnumerator ShieldDuration(int duration)
    {
        yield return new WaitUntil(() => IsNextTurn());
        shieldAmount = 0; // Shield expires
    }

    public void ApplyBurn(int damage, int duration)
    {
        FireBall.Play();
        isBurning = true;
        StartCoroutine(BurnDamage(damage, duration));
    }

    private IEnumerator BurnDamage(int damage, int duration)
    {
        for (int i = 0; i < duration; i++)
        {
            yield return new WaitUntil(() => IsNextTurn());
            if (isBurning) TakeDamage(damage);
        }
        isBurning = false;
    }

    public void RemoveBurn()
    {
        Cleansing.Play();
        isBurning = false;
    }

    public IEnumerator Regenerate(int healAmount, int duration)
    {
        for (int i = 0; i < duration; i++)
        {
            yield return new WaitUntil(() => IsNextTurn());
            health += healAmount;
            Heal.Play();
        }
    }

    private bool IsNextTurn()
    {
        return FindObjectOfType<GameServer>().IsPlayerTurn() == false; // check end turn
    }
}
