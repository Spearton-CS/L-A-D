using UnityEngine;

public class TheEnd : MonoBehaviour
{
    [SerializeField]
    private GameObject Text;
    private void Start()
    {
        if (PlayerPrefs.HasKey("IsEnd") && PlayerPrefs.GetInt("IsEnd") == 1)
            Text.SetActive(true);
        else
            Text.SetActive(false);
    }
}