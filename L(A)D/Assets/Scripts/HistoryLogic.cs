using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HistoryLogic : MonoBehaviour
{
    [SerializeField]
    private float Cooldown = 2;
    private Image Box;
    [SerializeField]
    private Sprite[] Sprites;
    private float F = 0;
    private int Step = 0;
    private void Start() => Box = GetComponent<Image>();
    private void Update()
    {
        if (Step == Sprites.Length - 1)
        {
            Destroy(this);
            SceneManager.LoadScene("Game");
        }
        if (F <= 0)
        {
            Box.sprite = Sprites[Step];
            F = Cooldown;
        }
        else
            F -= Time.deltaTime;
    }
}