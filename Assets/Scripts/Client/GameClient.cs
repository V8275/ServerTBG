using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Playables;

public class GameClient : MonoBehaviour, IGameClient
{
    public GameManager gameManager;

    public void UpdateHealth(int playerHealth, int enemyHealth)
    {
        
    }

    public void UpdateAbilities(List<Ability> playerAbilities)
    {
        
    }

    public void ShowMessage(string message)
    {
        
    }
}
