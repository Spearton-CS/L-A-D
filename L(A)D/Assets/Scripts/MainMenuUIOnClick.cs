using UnityEngine;

public class MainMenuUIOnClick : MonoBehaviour
{
    [SerializeField]
    private MainMenuLogic Logic;
    [SerializeField]
    private int F;
    private void OnMouseDown()
    {
        switch (F)
        {
            case 0:
                Logic.OnNewGameClick();
                break;
            case 1:
                Logic.OnSettingsClick();
                break;
            case 2:
                Logic.OnHistoryClick();
                break;
            case 3:
                Logic.OnExitSettingsClick();
                break;
            case 4:
                Logic.OnHistoryExit();
                break;
            default:
                Logic.OnExitClick();
                break;
        }
    }
}