using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BounceCounter : MonoBehaviour
{
    private int bounces;

    void OnCollisionEnter(Collision collision)
    {
        bounces++;
        string other = collision.gameObject.name;
        float impactSpeed = collision.relativeVelocity.magnitude;
        Debug.Log($"Bounce {bounces} on {other}, {impactSpeed:0.0} m/s");
    }
}