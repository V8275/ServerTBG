using UnityEngine;
using UnityEngine.UI;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private Button attackButton;
    [SerializeField] private Button barrierButton;
    [SerializeField] private Button regenerationButton;
    [SerializeField] private Button fireballButton;
    [SerializeField] private Button cleansingButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Text Log;

    private GameServer gameServer;

    void Start()
    {
        gameServer = FindObjectOfType<GameServer>();

        attackButton.onClick.AddListener(() => UseAbility("Attack"));
        barrierButton.onClick.AddListener(() => UseAbility("Barrier"));
        regenerationButton.onClick.AddListener(() => UseAbility("Regeneration"));
        fireballButton.onClick.AddListener(() => UseAbility("Fireball"));
        cleansingButton.onClick.AddListener(() => UseAbility("Cleansing"));
        restartButton.onClick.AddListener(RestartGame);
    }

    private void UseAbility(string abilityName)
    {
        string gameState = gameServer.ProcessAction(abilityName);
        Debug.Log(gameState);
        Log.text = $"{gameState}\n {Log.text}";
    }

    private void RestartGame()
    {
        gameServer.RestartGame();
    }
}
