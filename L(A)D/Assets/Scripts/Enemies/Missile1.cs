using UnityEngine;

public class Missile1 : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    public float Damage;
    private float dieCD = 5f;

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
        if(go.tag != "Enemy")
        {
            GetComponent<Collider2D>().isTrigger = true;
            dieCD = 0;
            if (go.tag == "Player")
                go.GetComponent<PlayerLogic>().Attack(Damage);
        }
        _ = go;
    }
}