using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField]
    private float Range = 0.5F;
    [SerializeField]
    private GameObject Object;
    void Update()
    {
        if (Object == null)
            return;
        Transform camera = base.transform;
        Transform transform = Object.transform;
        camera.position = new Vector3(camera.position.x + (transform.position.x - camera.position.x) * Time.deltaTime * 5, camera.position.y + (transform.position.y - camera.position.y) * Time.deltaTime * 5, camera.position.z);
        if (Mathf.Abs(camera.position.x - transform.position.x) > Range)
            camera.position = new Vector3(transform.position.x + (Mathf.Sign(camera.position.x - transform.position.x) * Range), camera.position.y, camera.position.z);
        if (Mathf.Abs(camera.position.y - transform.position.y) > Range)
            camera.position = new Vector3(camera.position.x, transform.position.y + (Mathf.Sign(camera.position.y - transform.position.y) * Range), camera.position.z);
    }
}