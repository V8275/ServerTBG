using UnityEngine;

public class EnemyAdapter : MonoBehaviour, IAttack
{
    private Enemy _enemy;

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Attack()
    {
        _enemy.SpecificAttack();
    }
}
