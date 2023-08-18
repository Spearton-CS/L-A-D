using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    #region Die
    private protected virtual void BeforeDie() { }
    private protected void Die()
    {
        BeforeDie();
        game.Cash += Cost;
        Destroy(gameObject);
    }
    #endregion
    #region Stats
    [SerializeField]
    private protected float Health;
    [SerializeField]
    private protected float MaxHealth;
    [SerializeField]
    private protected float Damage;
    [SerializeField]
    private protected float Speed;
    [SerializeField]
    private protected float DamageRange;
    [SerializeField]
    private protected int Cost;
    private protected float DamageCD = 0.7f;
    #endregion
    private GameLogic game;
    private protected Rigidbody2D Body;
    private protected CapsuleCollider2D Coll;
    private protected Animator Anim;
    private protected GameObject Player;
    private protected void InternalStart() { }
    private void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        Coll = GetComponent<CapsuleCollider2D>();
        Anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<GameLogic>();
        InternalStart();
    }
    #region Attack & Heal
    public bool canAttack(LayerMask mask)
    {
        return DamageRange/10 + (Coll.size.x + Coll.size.y)/2 + 0.7f >= Vector2.Distance(transform.position, Player.transform.position);
    }
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
        if (MaxHealth <= (Health + hp))
            Health = MaxHealth;
        else
            Health += hp;
    }
    private protected virtual void CustomOnCollisionEnter2D(Collision2D collision) { }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            
    }
    #endregion
    #region Movement
    private protected virtual void GoToPlayer() => transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
    private protected virtual void GoFromPlayer() =>  transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, -Speed * Time.deltaTime);
    #endregion
}