using UnityEngine;
using UnityEngine.UI;

public class HistoryLogic : MonoBehaviour
{
    private const string Text1 = "Nikita went to Burger King (McDonald's) every day and bought the largest set of food...", Text2 = "And one day the workers of Burger King (McDonald's) refused to sell it to him.", Text3 = "After that he took over the world, becoming the goblin king";
    [SerializeField]
    private Text Text;
    [SerializeField]
    private MainMenuLogic Logic;
    private void OnMouseDown()
    {
        switch (Text.text)
        {
            case Text1:
                Logic.DoAnim();
                Text.text = Text2;
                break;
            case Text2:
                Logic.DoAnim();
                Text.text = Text3;
                break;
            case Text3:
                Logic.DoAnim();
                Text.text = Text1;
                Logic.OnHistoryExitClick();
                break;
        }
    }
}