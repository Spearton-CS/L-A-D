using UnityEngine;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        #region Die
        private protected virtual void BeforeDie() { }
        private protected virtual void AfterDie() { }
        private protected void Die()
        {
            BeforeDie();
            Destroy(gameObject);
            AfterDie();
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
        #endregion
        [SerializeField]
        private protected readonly Animators.EnemyAnimator Animator;
        [SerializeField]
        private protected readonly GameObject Player;
        #region Attack & Heal
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
            if (collision.gameObject.tag == "Missile")
                Attack(collision.gameObject.GetComponent<Missile>().Damage);
            else
                CustomOnCollisionEnter2D(collision);
        }
        #endregion
    }
}