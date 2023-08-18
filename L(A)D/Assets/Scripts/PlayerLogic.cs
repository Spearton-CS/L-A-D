using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject Menu;
    [SerializeField]
    private GameObject Game;
    [SerializeField]
    private GameObject missile;
    [SerializeField]
    private Text HealthTxt;
    private Rigidbody2D Body;
    public float Health;
    public float MaxHealth = 100;
    public float Speed = 15F;
    public float Damage = 10;
    private float DamageRange = 13;
    public float SpellSpeed = 20f;
    public float SpellCD = 2f;
    private float practicSpellCD = 2f;
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
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
    }
    private void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        Health = MaxHealth;
    }
    private void Update()
    {
        HealthTxt.text = $"{Health}";
        if (Input.GetKey(KeyCode.Escape))
        {
            Game.SetActive(false);
            Menu.SetActive(true);
            Time.timeScale = 0;
            return;
        }
        GameObject[] goblins = GameObject.FindGameObjectsWithTag("Enemy");
        int nearest = 0;
        bool isCast = false;
        for (int i = 0; i < goblins.Length; i++)
        {
            if (Dist(i, goblins) < Dist(nearest, goblins) && isCast)
                nearest = i;
            else if (Dist(i, goblins) <= DamageRange)
            {
                isCast = true;
                nearest = i;
            }
        }
        Body.velocity = new(Input.GetAxis("Horizontal") * Speed, Input.GetAxis("Vertical") * Speed);
        if (!isCast) return;
        if (practicSpellCD == SpellCD)
        {
            Vector3 difference = transform.position - goblins[nearest].transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            missile.transform.rotation = Quaternion.Euler(0, 0, rotZ + 90);
            missile.transform.position = transform.position;
            missile.GetComponent<Missile>().Damage = Damage;
            missile.GetComponent<Missile>().Speed = SpellSpeed;
            Instantiate(missile);
            practicSpellCD -= Time.deltaTime;
        }
        else if (practicSpellCD > 0f)
            practicSpellCD -= Time.deltaTime;
        else
            practicSpellCD = SpellCD;
    }
    private float Dist(int i, GameObject[] obj)
    {
        return Vector2.Distance(transform.position, obj[i].transform.position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heart")
        {
            Heal(10);
            Destroy(collision.gameObject);
        }
    }
}