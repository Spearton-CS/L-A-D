using UnityEngine;

namespace Enemies
{
    /// <summary>Base (NON-ABSTRACT!!!) class for enemy in close combat</summary>
    public class CloseCombatEnemy : Enemy
    {
        private void Update()
        {
            Vector3 ppos = Player.transform.position;
            Vector3 pos = transform.position;
            GoToPlayer();
            if (DamageCD == 1f)
            {
                if (Mathf.Sqrt((ppos.x - pos.x) * (ppos.x - pos.x) + (ppos.y - pos.y) * (ppos.y - pos.y)) < DamageRange / 10 + 0.7f)
                {
                    Player.GetComponent<PlayerLogic>().Attack(Damage);
                    GoFromPlayer();
                } 
                DamageCD -= Time.deltaTime;
            }
            else if (DamageCD > 0)
                DamageCD -= Time.deltaTime;
            else
                DamageCD = 1f;
            _ = ppos;
            _ = pos;
        }
    }
}