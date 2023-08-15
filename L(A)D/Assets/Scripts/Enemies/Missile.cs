using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Missile : Enemies.Enemy
{
    /// <summary>if nearest than zero calculates range by object size</summary>
    [SerializeField]
    private float MaxFlightRange;
    private float CalculateMaxFlightRange() => transform.localScale.x * transform.localScale.y * 0.1F;
    public void Fire(GameObject to)
    {
        float range;
        if (MaxFlightRange <= 0)
            range = CalculateMaxFlightRange();
        else
            range = MaxFlightRange;
        float h = Mathf.Sign(to.transform.position.x - transform.position.x), v = Mathf.Sign(to.transform.position.y - transform.position.y);
        Body.velocity = new(h * range, v * range);
    }
    public static Missile Create(GameObject obj)
    {
        obj.AddComponent<Missile>();
        return obj.GetComponent<Missile>();
    }
    #region Objects
    private static GameObject Copy(string name) => Instantiate(SceneManager.GetActiveScene().GetRootGameObjects().Where((x) => x.name == name).First(), new Vector3(), new Quaternion(0, 0, 0, 0));
    public static GameObject Fireball => Copy("Fireball");
    public static GameObject Arrow => Copy("Arrow");
    public static GameObject Energy => Copy("Energy");
    public static GameObject Water => Copy("Water");
    #endregion
}