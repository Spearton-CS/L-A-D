using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject Game;
    [SerializeField]
    private GameObject Menu;
    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("MainMenu"); //0
        Time.timeScale = 1;
    }
    public void OnGoBackClick() //1
    {
        Game.SetActive(true);
        Menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnExitClick() => Application.Quit(); //2+
}