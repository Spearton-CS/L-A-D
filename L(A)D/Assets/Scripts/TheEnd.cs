using UnityEngine;

public class TheEnd : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.HasKey("TheEnd") && PlayerPrefs.GetInt("TheEnd") >= 1)
            gameObject.SetActive(true);
    }
}