using System.Collections.Generic;

public interface IGameClient
{
    void UpdateHealth(int playerHealth, int enemyHealth);
    void UpdateAbilities(List<Ability> playerAbilities);
    void ShowMessage(string message);
}
