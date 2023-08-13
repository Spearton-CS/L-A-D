using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private Animator Anim;
    private Rigidbody2D Body;
    private float Health;
    [SerializeField]
    private float MaxHealth = 100;
    [SerializeField]
    private float Speed = 1.5F;
    [SerializeField]
    private float Damage = 20;
    public void Attack(float dmg)
    {
        if (dmg <= 0)
            return;
        if (Health <= dmg)
            Die();
        else
            Health -= dmg;
    }
    public void Heal(float hp)
    {
        if (hp <= 0 || Health == MaxHealth)
            return;
        if (Health + hp > MaxHealth)
            Health = MaxHealth;
        else
            Health += hp;
    }
    private void Die()
    {
        //Before
        Destroy(gameObject);
        //After
    }
    private void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Health = MaxHealth;
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal"), v = Input.GetAxis("Vertical");
        Body.velocity = new Vector2(h * Speed, v * Speed);
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