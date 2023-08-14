using UnityEngine;

namespace Enemies
{
    /// <summary>Base (NON-ABSTRACT!!!) class for enemy in close combat</summary>
    public class CloseCombatEnemy : Enemy
    {
        private float damageCD = 1f;
        private void Update()
        {
            GoToPlayer();
            if(damageCD == 1f)
            {
                if (Physics2D.OverlapCircle(transform.position, DamageRange, 7))
                    Player.GetComponent<PlayerLogic>().Attack(Damage);
            }
            else if(damageCD > 0f)
                damageCD -= Time.deltaTime;
            else
                damageCD = 1f;
        }
    }
}