using UnityEngine;

public class GameServer : MonoBehaviour, IGameServer
{
    public Unit playerUnit;
    public Unit enemyUnit;
    private IGameClient gameClient;

    public void Initialize(IGameClient client)
    {
        gameClient = client;
    }

    public void PlayerAction(Ability ability)
    {
        gameClient.UpdateHealth(playerUnit.currentHealth, enemyUnit.currentHealth);
    }

    public void EnemyAction()
    {
        gameClient.UpdateHealth(playerUnit.currentHealth, enemyUnit.currentHealth);
    }

    public void RestartGame()
    {
        
    }
}
