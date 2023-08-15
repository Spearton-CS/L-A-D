using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject Menu;
    [SerializeField]
    private GameObject Game;
    private Animator Anim;
    private Rigidbody2D Body;
    public float Health;
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
        SceneManager.LoadScene("MainMenu");
    }
    private void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Health = MaxHealth;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Game.SetActive(false);
            Menu.SetActive(true);
            Time.timeScale = 0;
            return;
        }
        Body.velocity = new(Input.GetAxis("Horizontal") * Speed, Input.GetAxis("Vertical") * Speed);
    }
}