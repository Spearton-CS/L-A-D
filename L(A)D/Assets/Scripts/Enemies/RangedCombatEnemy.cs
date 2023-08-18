using UnityEngine;

public class RangedCombatEnemy : Enemy
{
    [SerializeField]
    private GameObject arrow;
    private void Update()
    {
        if (Vector2.Distance(Player.transform.position, transform.position) < (Coll.size.x + Coll.size.y) / 2 + DamageRange / 10)
            GoFromPlayer();
        else
            GoToPlayer();
        if (DamageCD == 1f && canAttack(7))
        {
            Vector3 difference = transform.position - Player.transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            arrow.transform.rotation = Quaternion.Euler(0, 0, rotZ + 90);
            arrow.transform.position = transform.position;
            Instantiate(arrow);
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