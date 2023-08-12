using UnityEngine;

public class MainMenuLogic : MonoBehaviour
{
    [SerializeField]
    private Camera Camera;
    [SerializeField]
    private GameObject NewGameMenu;
    [SerializeField]
    private GameObject SettingsMenu;
    [SerializeField]
    private GameObject MainMenu;
    [SerializeField]
    private GameObject Animation;
    [SerializeField]
    private GameObject NewGameMenuLight;
    [SerializeField]
    private GameObject SettingsMenuLight;
    [SerializeField]
    private GameObject MainMenuLight;
    [SerializeField]
    private GameObject AnimationLight;
    [HideInInspector]
    private bool LightTheme = false;
    private void Start()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsConstants.Theme))
        {
            PlayerPrefs.SetInt(PlayerPrefsConstants.Theme, 0);
            PlayerPrefs.Save();
        }
        else if (PlayerPrefs.GetInt(PlayerPrefsConstants.Theme) > 0)
            LightTheme = true;
    }
    public void OnNewGameClick()
    {
        MainMenu.SetActive(false);
        //Анимация перехода
        NewGameMenu.SetActive(true);
    }
    public void OnSettingsClick()
    {
        MainMenu.SetActive(false);
        //Анимация перехода
        SettingsMenu.SetActive(true);
    }
    public void OnExitNewGameClick()
    {
        NewGameMenu.SetActive(false);
        //Анимация перехода
        MainMenu.SetActive(true);
    }
    public void OnExitSettingsClick()
    {
        SettingsMenu.SetActive(false);
        //Анимация перехода
        MainMenu.SetActive(true);
    }
    public void OnExitClick() => Application.Quit();
}