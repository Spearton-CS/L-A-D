using UnityEngine;

public class CloseCombatEnemy : Enemy
{
    private void Update()
    {
        if (Vector2.Distance(Player.transform.position, transform.position) < (Coll.size.x + Coll.size.y) / 2 + DamageRange / 10)
            GoFromPlayer();
        else
            GoToPlayer();
        if (DamageCD == 1f && canAttack(7))
        {
            Player.GetComponent<PlayerLogic>().Attack(Damage);
            Anim.SetBool("Punch", true);
            DamageCD -= Time.deltaTime;
        }
        else if (DamageCD > 0)
        {
            Anim.SetBool("Punch", false);
            DamageCD -= Time.deltaTime;
        }
        else
            DamageCD = 1f;
        Body.velocity = Vector3.zero;
    }
}