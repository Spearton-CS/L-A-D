using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOnClick : MonoBehaviour
{
    [SerializeField]
    private MainMenuLogic logic;
    [SerializeField]
    private int f;

    private void OnMouseDown()
    {
        switch (f)
        {
            case 0:
                logic.OnNewGameClick();
                break;
            case 1:
                logic.OnSettingsClick();
                break;
            case 2:
                logic.OnExitNewGameClick();
                break;
            case 3:
                logic.OnExitSettingsClick();
                break;
            default:
                logic.OnExitClick();
                break;
        }
    }
}
