using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : CloseCombatEnemy
{
    private protected override void BeforeDie()
    {
        PlayerPrefs.SetInt("IsEnd", 1);
        SceneManager.LoadScene("MainMenu");
    }
}