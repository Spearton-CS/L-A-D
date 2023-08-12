using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandling : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    [SerializeField]
    private float speed;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal"), v = Input.GetAxis("Vertical");
        body.velocity = new Vector2(h * speed, v * speed);
        
        if(!(Mathf.Abs(h) < 0.2 && Mathf.Abs(v) < 0.2))
        {
            if (Mathf.Abs(h) < Mathf.Abs(v))
            {
                if (v < 0)
                    anim.SetInteger("State", 0);
                else
                    anim.SetInteger("State", 2);
            }
            else
            {
                anim.SetInteger("State", 1);
                transform.localScale = new Vector3(Mathf.Sign(h) * -1, 1, 1);
            }
        }
    }
}
