using UnityEngine;
using UnityEngine.UI;

public class HistoryLogic : MonoBehaviour
{
    private const string Text1 = "Nikita went to Burger King (McDonald's) every day and bought the largest set of food...", Text2 = "And one day the workers of Burger King (McDonald's) refused to sell it to him.", Text3 = "After that he took over the world, becoming the goblin king";
    [SerializeField]
    private Text Text;
    [SerializeField]
    private MainMenuLogic Logic;
    private int nowText = 1;
    private float textCD = -1;
    private void Update()
    {
        if (textCD > 0)
            textCD -= Time.deltaTime;
        else if (textCD > -1)
        {
            if(nowText == 1)
                Text.text = Text2;
            else
                Text.text = Text3;
        }
            

    }
    private void OnMouseDown()
    {
        switch (Text.text)
        {
            case Text1:
                Logic.DoAnim();
                textCD = 0.5f;
                break;
            case Text2:
                Logic.DoAnim();
                textCD = 0.5f;
                nowText = 2;
                break;
            case Text3:
                Logic.OnHistoryExitClick();
                Text.text = Text1;
                break;
        }
    }
}