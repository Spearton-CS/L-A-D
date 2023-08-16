using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject Menu;
    [SerializeField]
    private GameObject Game;
    private Rigidbody2D Body;
    public float Health;
    public float SpellCD = 2f;
    public float MaxHealth = 100;
    public float Speed = 15F;

    public Dictionary<GameObject, int> spells = new();
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