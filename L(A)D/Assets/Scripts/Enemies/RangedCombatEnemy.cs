using UnityEngine;

/// <summary>Base (NON-ABSTRACT!!!) class for enemy in ranged combat</summary>
public class RangedCombatEnemy : Enemy
{
    [SerializeField]
    private protected readonly int MissileObjectIndex;
    private void Update()
    {
        /*
            * Логику сам пиши, я нихуя не понял в CloseCombatEnemy... меня плавит, я выгораю
            * 
            * ГЛАВНОЕ!!! чтобы нпс с этой логикой были в дальности атаки игрока (чуть ближе, например.. на 0.1% или 0.5%)
        */
    }
        
}