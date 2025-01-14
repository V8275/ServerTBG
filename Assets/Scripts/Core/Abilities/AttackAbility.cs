using UnityEngine;

public class AttackAbility : Ability
{
    public int damage = 8;

    public override void Use(Unit target)
    {
        target.TakeDamage(damage);
    }
}
