using UnityEngine;

public class Missile : MonoBehaviour
{
    public float Speed;
    public float Damage;
    private Animator Anim;
    private float DieCD = 5f;
    private void Start()
    {
        Anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (DieCD < 4.95f && DieCD > 4.9f)
            GetComponent<Collider2D>().isTrigger = false;
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
        DieCD -= Time.deltaTime;
        if (DieCD < 0)
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = collision.gameObject;
        if (go.tag != "Player")
        {
            Anim.SetBool("IsDestroy", true);
            DieCD = 0.3f;
            if (go.GetComponent<CloseCombatEnemy>())
            {
                if (!go.GetComponent<CloseCombatEnemy>().CanKill(Damage))
                    GetComponent<Collider2D>().isTrigger = true;
                go.GetComponent<CloseCombatEnemy>().Attack(Damage);
            }
            else
            {
                if (!go.GetComponent<RangedCombatEnemy>().CanKill(Damage))
                    GetComponent<Collider2D>().isTrigger = true;
                go.GetComponent<RangedCombatEnemy>().Attack(Damage);
            }
        }
        Damage /= 2;
        _ = go;
    }
}