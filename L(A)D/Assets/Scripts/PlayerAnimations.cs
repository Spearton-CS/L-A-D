using UnityEngine;

public class ObjectAnimations : MonoBehaviour
{
    private Rigidbody2D Body;
    private Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
        Body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 vel = Body.velocity;
        if (!(Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2 && Mathf.Abs(Input.GetAxis("Vertical")) < 0.2))
            if (Mathf.Abs(vel.x) < Mathf.Abs(vel.y))
                if (vel.y < 0)
                    Anim.SetInteger("State", 0);
                else
                    Anim.SetInteger("State", 2);
            else
            {
                Anim.SetInteger("State", 1);
                transform.localScale = new(Mathf.Sign(vel.x) * -1, 1, 1);
            }
        _ = vel;
    }
}