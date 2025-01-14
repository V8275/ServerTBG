using UnityEngine;

public class GameAdapter : MonoBehaviour
{
    private GameServer gameServer;
    private GameClient gameClient;

    private void Start()
    {
        gameServer = new GameServer();
        gameClient = new GameClient();

        gameServer.Initialize(gameClient);
    }

    private void Update()
    {
        
    }
}