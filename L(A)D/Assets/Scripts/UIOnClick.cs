using UnityEngine;

public class UIOnClick : MonoBehaviour
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
                Logic.OnExitNewGameClick();
                break;
            case 3:
                Logic.OnExitSettingsClick();
                break;
            default:
                Logic.OnExitClick();
                break;
        }
    }
}