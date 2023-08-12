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
    private float AnimCD = 0f;
    private int AnimState = 0;
    private int nowClick = 0;
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

    private void Update()
    {
        if(AnimState == 1)
        {
            if(AnimCD > 0f)
                AnimCD -=Time.deltaTime;
            else
            {
                AnimCD = 0.5f;
                AnimState = 2;
                switch (nowClick)
                {
                    case 0:
                        MainMenu.SetActive(false);
                        NewGameMenu.SetActive(true);
                        break;
                    case 1:
                        MainMenu.SetActive(false);
                        SettingsMenu.SetActive(true);
                        break;
                    case 2:
                        MainMenu.SetActive(true);
                        NewGameMenu.SetActive(false);
                        break;
                    default:
                        MainMenu.SetActive(true);
                        SettingsMenu.SetActive(false);
                        break;
                }
            }
            Animation.transform.position = new Vector3(-5000 + (1 - AnimCD / 0.5f) * 8000, -1000, -9);
        }
        else if(AnimState == 2)
        {
            if (AnimCD > 0f)
                AnimCD -= Time.deltaTime;
            else
            {
                AnimCD = 0f;
                AnimState = 0;
            }
            Animation.transform.position = new Vector3(3000 - (1 - AnimCD / 0.5f) * 8000, -1000, -9);
        }
        
    }

    public void OnNewGameClick() // 0
    {
        AnimCD = 0.5f;
        AnimState = 1;
        nowClick = 0;
    }
    public void OnSettingsClick() // 1
    {
        AnimCD = 0.5f;
        AnimState = 1;
        nowClick = 1;
    }
    public void OnExitNewGameClick() // 2
    {
        AnimCD = 0.5f;
        AnimState = 1;
        nowClick = 2;
    }
    public void OnExitSettingsClick() // 3
    {
        AnimCD = 0.5f;
        AnimState = 1;
        nowClick = 3;
    }

    public void OnExitClick() => Application.Quit(); // 4
}