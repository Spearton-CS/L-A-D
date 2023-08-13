using UnityEngine;

namespace Enemies.Animators
{
    public abstract class EnemyAnimator : MonoBehaviour
    {
        public abstract void AnimateBeforeAttack(float h, float v);
        public abstract void AnimateAfterAttack(float h, float v);
    }
}