using UnityEngine;

public class Player : MonoBehaviour, IAttack
{
    public int Health = 100;
    public int Damage = 20;

    public void Attack()
    {
        // Логика атаки игрока
        Debug.Log("Игрок атакует врага, нанося " + Damage + " урона.");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log("Игрок получил " + damage + " урона. Осталось здоровья: " + Health);
    }
}
