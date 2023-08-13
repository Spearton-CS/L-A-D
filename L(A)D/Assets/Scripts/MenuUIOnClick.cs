using UnityEngine;

public class MenuUIOnClick : MonoBehaviour
{
    [SerializeField]
    private GameObject Logic;
    [SerializeField]
    private int F;
    private void OnMouseDown()
    {
        if (F == 0)
            Logic.GetComponent<MenuLogic>().OnMainMenuClick();
        else if (F == 1)
            Logic.GetComponent<MenuLogic>().OnGoBackClick();
        else
            Logic.GetComponent<MenuLogic>().OnExitClick();
    }
}