public interface IGameServer
{
    string ProcessAction(string action);
    string GetGameState();
    void RestartGame();
}