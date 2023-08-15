using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (player.position.x < transform.position.x)
            transform.localScale = new(1, 1, 1);
        else
            transform.localScale = new(-1, 1, 1);
    }
}
