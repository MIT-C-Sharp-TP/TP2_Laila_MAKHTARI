using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0f, 2.2f, -4.5f);
    [SerializeField] private float smoothing = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 wanted = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, wanted, smoothing * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * 0.3f);
    }
}