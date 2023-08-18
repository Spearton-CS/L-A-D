using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject SettingsMenu;
    [SerializeField]
    private GameObject MainMenu;
    [SerializeField]
    private GameObject HistoryMenu;
    [SerializeField]
    private GameObject Animation;
    private float AnimCD = 0f;
    private int AnimState = 0;
    private int NowClick = 0;
    private void Start()
    {
        #region Settings
        if (PlayerPrefs.HasKey("Volume"))
        {
            float vol = PlayerPrefs.GetFloat("Volume");
            VolumeBar.value = vol;
            Volume.text = $"Volume: {Mathf.RoundToInt(vol * 100)}";
            _ = vol;
        }
        #endregion
    }
    private void Update()
    {
        if (AnimState == 1)
        {
            if (AnimCD > 0f)
                AnimCD -= Time.deltaTime;
            else
            {
                AnimCD = 0.5f;
                AnimState = 2;
                switch (NowClick)
                {
                    case -1:
                        break;
                    case 0:
                        MainMenu.SetActive(false);
                        SceneManager.LoadScene("Game");
                        break;
                    case 1:
                        MainMenu.SetActive(false);
                        SettingsMenu.SetActive(true);
                        break;
                    case 2:
                        MainMenu.SetActive(false);
                        HistoryMenu.SetActive(true);
                        break;
                    case 3:
                        SettingsMenu.SetActive(false);
                        MainMenu.SetActive(true);
                        break;
                    case 4:
                        HistoryMenu.SetActive(false);
                        MainMenu.SetActive(true);
                        break;
                    default:
                        Application.Quit();
                        break;
                }
            }
            Animation.transform.position = new(-4015 + (1 - AnimCD / 0.5f) * 7015, -1000, -9);
        }
        else if (AnimState == 2)
        {
            if (AnimCD > 0f)
                AnimCD -= Time.deltaTime;
            else
            {
                AnimCD = 0f;
                AnimState = 0;
            }
            Animation.transform.position = new(3000 - (1 - AnimCD / 0.5f) * 7015, -1000, -9);
        }
    }
    public void OnNewGameClick() // 0
    {
        DoAnim();
        NowClick = 0;
    }
    public void OnSettingsClick() // 1
    {
        DoAnim();
        NowClick = 1;
    }
    public void OnHistoryClick() // 2
    {
        DoAnim();
        NowClick = 2;
    }
    public void OnExitSettingsClick() // 3
    {
        DoAnim();
        NowClick = 3;
    }
    public void OnHistoryExitClick() // 4
    {
        DoAnim();
        NowClick = 4;
    }
    public void DoAnim()
    {
        AnimCD = 0.5f;
        AnimState = 1;
        NowClick = -1;
    }
    public void OnExitClick()
    {
        DoAnim();
        NowClick = 3;
    }
    #region Settings
    [SerializeField]
    private Text Volume;
    [SerializeField]
    private Scrollbar VolumeBar;
    public void SetVolume()
    {
        PlayerPrefs.SetFloat("Volume", VolumeBar.value);
        Volume.text = $"Volume: {Mathf.RoundToInt(VolumeBar.value * 100)}";
    }
    #endregion
}