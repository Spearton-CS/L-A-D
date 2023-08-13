using UnityEngine;

public class Missile : Enemies.Enemy
{
    /// <summary>if nearest than zero calculates range by object size</summary>
    [SerializeField]
    private float MaxFlightRange;
    private float CalculateMaxFlightRange() => transform.localScale.x * transform.localScale.y * 0.1F; //Redact later...
    public void Fire(GameObject to)
    {
        float range;
        if (MaxFlightRange <= 0)
            range = CalculateMaxFlightRange();
        else
            range = MaxFlightRange;
        //Redact later...
    }
    #region Objects
    public static GameObject Fireball()
    {
        return default;
    }
    public static GameObject Arrow()
    {
        return default;
    }
    public static GameObject Energy()
    {
        return default;
    }
    public static GameObject Water()
    {
        return default;
    }
    #endregion
}