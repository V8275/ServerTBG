using UnityEngine;

public class Player : MonoBehaviour, IAttack
{
    public int Health = 100;
    public int Damage = 20;

    public void Attack()
    {
        // ������ ����� ������
        Debug.Log("����� ������� �����, ������ " + Damage + " �����.");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log("����� ������� " + damage + " �����. �������� ��������: " + Health);
    }
}
