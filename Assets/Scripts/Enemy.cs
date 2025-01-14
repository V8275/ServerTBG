using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 100;
     public int Damage = 15;

    public void SpecificAttack()
    {
        // ������ ����� �����
        Debug.Log("���� ������� ������, ������ " + Damage + " �����.");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log("���� ������� " + damage + " �����. �������� ��������: " + Health);
    }
}
