using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipHistory : MonoBehaviour
{
    [SerializeField]
    private Text Text;
    private const string Text1 = "Nikita went to Burger King (McDonald's) every day and bought the largest set of food...";

    private void OnMouseDown()
    {
        Text.text = Text1;
    }
}
