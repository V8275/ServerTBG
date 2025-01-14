public interface IGameServer
{
    void PlayerAction(Ability ability);
    void EnemyAction();
    void RestartGame();
}
