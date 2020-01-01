using UnityEngine;

public class Camera_contrl : MonoBehaviour
{
    public Transform cam, target;
    public float speed;
    public float r_speed;

    private void Update()
    {
        Vector3 pos = Vector3.Lerp(cam.position, target.position, 0.5f * speed * Time.deltaTime);
        cam.position = pos;
        float r = Input.GetAxis("Horizontal");
        cam.Rotate(0, r_speed * r * Time.deltaTime, 0);
    }
}
