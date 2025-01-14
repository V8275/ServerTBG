using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public string abilityName;
    public int cooldown;
    public int duration;

    public abstract void Use(Unit target);
}
