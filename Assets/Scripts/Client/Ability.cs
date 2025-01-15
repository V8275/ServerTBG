public class Ability
{
    public string Name { get; private set; }
    public int Damage { get; private set; }
    public int Heal { get; private set; }
    public int Shield { get; private set; }
    public int Duration { get; private set; }
    public int Cooldown { get; private set; }
    public int RemainingCooldown { get; private set; }
    public int RemainingDuration { get; private set; }
    public bool IsOnCooldown => RemainingCooldown > 0;

    public Ability(string name, int damage = 0, int heal = 0, int shield = 0, int duration = 0, int cooldown = 0)
    {
        Name = name;
        Damage = damage;
        Heal = heal;
        Shield = shield;
        Duration = duration;
        Cooldown = cooldown;
        RemainingCooldown = 0;
        RemainingDuration = 0;
    }

    public void Use(Unit caster, Unit target)
    {
        switch (Name)
        {
            case "Attack":
                target.TakeDamage(Damage);
                break;
            case "Barrier":
                caster.ApplyShield(Shield, Duration);
                break;
            case "Regeneration":
                caster.StartCoroutine(caster.Regenerate(Heal, Duration));
                break;
            case "Fireball":
                target.TakeDamage(Damage);
                target.ApplyBurn(1, Duration);
                break;
            case "Cleansing":
                caster.RemoveBurn();
                break;
        }

        StartCooldown();
    }

    public void StartCooldown()
    {
        RemainingCooldown = Cooldown;
    }

    public void UpdateCooldown()
    {
        if (RemainingCooldown > 0) RemainingCooldown--;
        if (RemainingDuration > 0) RemainingDuration--;
    }
}
