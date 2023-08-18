using UnityEngine;

public class TheEnd : MonoBehaviour
{
    private void Update()
    {
        if (PlayerPrefs.HasKey("IsEnd"))
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}