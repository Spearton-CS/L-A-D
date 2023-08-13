using UnityEngine;

public class BordersLogic : MonoBehaviour
{
    [SerializeField]
    private float Damage = 0.5F;
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Player")
            return;
        float x = collider.transform.position.x, y = collider.transform.position.y;
        switch (tag)
        {
            case "TopBorder":
                y -= 2;
                break;
            case "BottomBorder":
                y += 2;
                break;
            case "LeftBorder":
                x += 2;
                break;
            case "RightBorder":
                x -= 2;
                break;
            default:
                Debug.LogError("Unsupported object tag; All actions skipped");
                break;
        }
        collider.transform.position = new(x, y, collider.transform.position.z);
        collider.gameObject.GetComponent<PlayerLogic>().Attack(Damage);
        _ = x;
        _ = y;
    }
}