using UnityEngine;

namespace Enemies
{
    /// <summary>Base (NON-ABSTRACT!!!) class for enemy in ranged combat</summary>
    public class RangedCombatEnemy : Enemy
    {
        [SerializeField]
        private protected readonly GameObject MissileObject;
        private void Update()
        {
        
        }
    }
}