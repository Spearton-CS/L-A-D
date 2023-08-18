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
            Damage /= 2;
            DieCD = 0.3f;
            if (go.GetComponent<CloseCombatEnemy>())
                go.GetComponent<CloseCombatEnemy>().Attack(Damage);
            else
                go.GetComponent<RangedCombatEnemy>().Attack(Damage);
        }
        _ = go;
    }
}