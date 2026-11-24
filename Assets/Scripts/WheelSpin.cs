using UnityEngine;

public class WheelSpin : MonoBehaviour
{
    [SerializeField] private Rigidbody car;
    [SerializeField] private float radius = 0.225f;

    void Update()
    {
        // vitesse vers l'avant de la voiture
        float forwardSpeed = Vector3.Dot(car.linearVelocity, car.transform.forward);
        float degrees = forwardSpeed / radius * Mathf.Rad2Deg * Time.deltaTime;
        transform.Rotate(0f, degrees, 0f, Space.Self);
    }
}