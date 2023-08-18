using UnityEngine;

public class Missile : MonoBehaviour
{
    public float Speed;
    public float Damage;
    private Animator Anim;
    private float dieCD = 5f;
    private void Start()
    {
        Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(dieCD < 4.9f && dieCD > 4.8f) GetComponent<Collider2D>().isTrigger = false;
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
        dieCD -= Time.deltaTime;
        if(dieCD < 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = collision.gameObject;
        if(go.tag != "Player")
        {
            Anim.SetBool("IsDestroy", true);
            GetComponent<Collider2D>().isTrigger = true;
            dieCD = 0.2f;
            if (go.GetComponent<CloseCombatEnemy>())
                go.GetComponent<CloseCombatEnemy>().Attack(Damage);
            else
                go.GetComponent<RangedCombatEnemy>().Attack(Damage);
               
        }
        _ = go;
    }
}