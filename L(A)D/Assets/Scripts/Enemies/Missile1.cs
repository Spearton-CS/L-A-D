using UnityEngine;

public class Missile1 : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    public float Damage;
    private float DieCD = 5f;
    private void Update()
    {
        if(DieCD < 4.9f && DieCD > 4.8f) GetComponent<Collider2D>().isTrigger = false;
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
        DieCD -= Time.deltaTime;
        if(DieCD < 0)
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && (collision.gameObject.GetComponent<Boss>() || collision.gameObject.tag == "Player"))
        {
            GetComponent<Collider2D>().isTrigger = true;
            DieCD = 0;
            if (collision.gameObject.tag == "Player")
                collision.gameObject.GetComponent<PlayerLogic>().Attack(Damage);
        }
    }
}