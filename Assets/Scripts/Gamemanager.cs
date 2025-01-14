using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    private EnemyAdapter enemyAdapter;
    private bool playerTurn = true; // ���������� ��� ������������ ���� ������

    void Start()
    {
        enemyAdapter = enemy.gameObject.AddComponent<EnemyAdapter>();
        enemyAdapter.Initialize(enemy);

        StartBattle();
    }

    void Update()
    {
        // ���������, ���� ��� ������ � ������ ������� "Space"
        if (playerTurn && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerAttack();
        }
    }

    void StartBattle()
    {
        Debug.Log("��� �������!");
    }

    void PlayerAttack()
    {
        // ����� ������� �����
        player.Attack();
        enemy.TakeDamage(player.Damage);

        if (enemy.Health <= 0)
        {
            Debug.Log("����� ������� �����!");
            return;
        }

        // ������ ��� �����
        EnemyAttack();
    }

    void EnemyAttack()
    {
        // ���� ������� ������
        enemyAdapter.Attack();
        player.TakeDamage(enemy.Damage);

        if (player.Health <= 0)
        {
            Debug.Log("���� ������� ������!");
            return;
        }

        // ��� ������ �����
        playerTurn = true;
    }
}
