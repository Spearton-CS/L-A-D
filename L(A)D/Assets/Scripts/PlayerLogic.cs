using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private Animator Anim;
    private Rigidbody2D body;
    private float Health;
    [SerializeField]
    private float MaxHealth = 100;
    [SerializeField]
    private float Speed = 1.5F;
    public void Damage(float dmg)
    {
        if (Health <= dmg)
            Die();
        else
            Health -= dmg;
        Debug.Log(Health);
    }
    public void Heal(float hp)
    {
        if (Health + hp > MaxHealth)
            Health = MaxHealth;
        else
            Health += hp;
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Health = MaxHealth;
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal"), v = Input.GetAxis("Vertical");
        body.velocity = new Vector2(h * Speed, v * Speed);
        if(!(Mathf.Abs(h) < 0.2 && Mathf.Abs(v) < 0.2))
            if (Mathf.Abs(h) < Mathf.Abs(v))
                if (v < 0)
                    Anim.SetInteger("State", 0);
                else
                    Anim.SetInteger("State", 2);
            else
            {
                Anim.SetInteger("State", 1);
                transform.localScale = new Vector3(Mathf.Sign(h) * -1, 1, 1);
            }
        _ = h;
        _ = v;
    }
}