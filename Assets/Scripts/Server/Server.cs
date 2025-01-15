using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameServer : MonoBehaviour, IGameServer
{
    private Unit player;
    private Unit enemy;
    private bool isPlayerTurn;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Unit>();
        enemy = GameObject.Find("Enemy").GetComponent<Unit>();
        isPlayerTurn = true;
        StartCoroutine(GameLoop());
    }

    public void EndTurn()
    {
        isPlayerTurn = false;
    }

    public bool IsPlayerTurn()
    {
        return isPlayerTurn;
    }

    private IEnumerator GameLoop()
    {
        while (player.Health > 0 && enemy.Health > 0)
        {
            if (isPlayerTurn)
            {
                yield return null; // Change Player ability
            }
            else
            {
                EnemyTurn();
                isPlayerTurn = true;
            }

            UpdateAbilities();
        }

        EndGame();
    }

    private void EnemyTurn()
    {
        // Enemy "AI"
        var abilities = new List<Ability>(enemy.Abilities.Values);
        var randomAbility = abilities[Random.Range(0, abilities.Count)];

        randomAbility.Use(enemy, player);
    }


    private void UpdateAbilities()
    {
        foreach (var ability in player.Abilities.Values)
        {
            ability.UpdateCooldown();
        }
        foreach (var ability in enemy.Abilities.Values)
        {
            ability.UpdateCooldown();
        }
    }

    private void EndGame()
    {
        StopAllCoroutines();
    }

    public void RestartGame()
    {
        player.Initialize("Player", 100);
        enemy.Initialize("Enemy", 100);
        StopAllCoroutines();
        isPlayerTurn = true;
        StartCoroutine(GameLoop());
    }

    public string ProcessAction(string action)
    {
        if (isPlayerTurn)
        {
            // check ability
            if (player.Abilities.TryGetValue(action, out Ability ability) && !ability.IsOnCooldown)
            {
                ability.Use(player, enemy);
                isPlayerTurn = false;
                return GetGameState(); // return info message
            }
            else
            {
                return "Ability on cooldown or not available!";
            }
        }
        if (player.Health <= 0)
        {
            return "Game Over. Enemy Win!";
        }
        else if (enemy.Health <= 0)
        {
            return "Game Over. Player Win!";
        }
        return "Not Player turn!";
    }

    public string GetGameState()
    {
        return $"PlayerHealth:{player.Health}, EnemyHealth:{enemy.Health}";
    }
}
