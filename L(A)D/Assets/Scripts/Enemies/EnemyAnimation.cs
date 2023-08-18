using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Transform Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (Player.position.x < transform.position.x)
            transform.localScale = new(1, 1, 1);
        else
            transform.localScale = new(-1, 1, 1);
    }
}