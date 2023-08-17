using UnityEngine;

public class RangedCombatEnemy : Enemy
{
    private void Update()
    {
        /*
            * Логика:
            * 
            * 1. Дойти до радиуса атаки игрока и подойти еще на 0.1 (или больший) % от радиуса
            * 
            * 2. Дрочить метод Fire по кд
            * 
            */
        Vector2 ppos = Player.transform.position;
        Vector2 pos = transform.position;
        PlayerLogic logic = Player.GetComponent<PlayerLogic>();
        float range = 1;
        if (Vector2.Distance(ppos, pos) <= range)
        {
            if (false == true) //Проверка кд...
                return;//Fire(new());
        }
        else //Поправить движение до радиуса...
        {
            float h = ppos.x - pos.x, v = ppos.y - pos.y;
            if (h < 0)
                h -= range;
            else
                h += range;
            if (v < 0)
                v -= range;
            else
                v += range;
            Body.velocity = new(h, v);
            _ = h;
            _ = v;
        }
        _ = ppos;
        _ = pos;
    }
}