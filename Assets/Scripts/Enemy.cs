using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 100;
     public int Damage = 15;

    public void SpecificAttack()
    {
        // Логика атаки врага
        Debug.Log("Враг атакует игрока, нанося " + Damage + " урона.");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log("Враг получил " + damage + " урона. Осталось здоровья: " + Health);
    }
}
