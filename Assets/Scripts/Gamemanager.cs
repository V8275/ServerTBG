using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    private EnemyAdapter enemyAdapter;
    private bool playerTurn = true; // Переменная для отслеживания хода игрока

    void Start()
    {
        enemyAdapter = enemy.gameObject.AddComponent<EnemyAdapter>();
        enemyAdapter.Initialize(enemy);

        StartBattle();
    }

    void Update()
    {
        // Проверяем, если ход игрока и нажата клавиша "Space"
        if (playerTurn && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerAttack();
        }
    }

    void StartBattle()
    {
        Debug.Log("Бой начался!");
    }

    void PlayerAttack()
    {
        // Игрок атакует врага
        player.Attack();
        enemy.TakeDamage(player.Damage);

        if (enemy.Health <= 0)
        {
            Debug.Log("Игрок победил врага!");
            return;
        }

        // Теперь ход врага
        EnemyAttack();
    }

    void EnemyAttack()
    {
        // Враг атакует игрока
        enemyAdapter.Attack();
        player.TakeDamage(enemy.Damage);

        if (player.Health <= 0)
        {
            Debug.Log("Враг победил игрока!");
            return;
        }

        // Ход игрока снова
        playerTurn = true;
    }
}
