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
        if(dieCD < 4.5f) GetComponent<Collider2D>().isTrigger = false;
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
            dieCD = 0.35f;
            if (go.tag == "Enemy")
                go.GetComponent<Enemies.CloseCombatEnemy>().Attack(Damage);
            else if (go.tag == "RangeEnemy")
                go.GetComponent<Enemies.RangedCombatEnemy>().Attack(Damage);
               
        }
        _ = go;
    }
}