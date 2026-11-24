using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    [Header("Driving")]
    [SerializeField] private float acceleration = 6f;
    [SerializeField] private float maxSpeed = 8f;
    [SerializeField] private float brakeForce = 14f;
    [SerializeField] private float drag = 1.5f;
    [SerializeField] private float turnSpeed = 80f;

    [Header("Jump")]
    [SerializeField] private float jumpSpeed = 4.5f;
    [SerializeField] private float groundCheck = 0.35f;

    private Rigidbody rb;
    private float throttle;
    private float steering;
    private bool braking;
    private bool jumpWanted;
    private float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        throttle = (keyboard.wKey.isPressed ? 1f : 0f) - (keyboard.sKey.isPressed ? 1f : 0f);
        steering = (keyboard.dKey.isPressed ? 1f : 0f) - (keyboard.aKey.isPressed ? 1f : 0f);
        braking = keyboard.leftShiftKey.isPressed;

        if (keyboard.spaceKey.wasPressedThisFrame)
            jumpWanted = true;
    }

    void FixedUpdate()
    {
        float step = Time.fixedDeltaTime;

        if (braking)
            speed = Mathf.MoveTowards(speed, 0f, brakeForce * step);
        else if (throttle != 0f)
            speed += throttle * acceleration * step;
        else
            speed = Mathf.MoveTowards(speed, 0f, drag * step);

        speed = Mathf.Clamp(speed, -maxSpeed * 0.4f, maxSpeed);

        Vector3 velocity = transform.forward * speed;
        velocity.y = rb.linearVelocity.y;
        rb.linearVelocity = velocity;

        if (Mathf.Abs(speed) > 0.3f)
        {
            float angle = steering * Mathf.Sign(speed) * turnSpeed * step;
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, angle, 0f));
        }

        if (jumpWanted)
        {
            jumpWanted = false;
            if (Grounded())
                rb.linearVelocity += Vector3.up * jumpSpeed;
        }
    }

    private bool Grounded()
    {
        Vector3 from = transform.position + Vector3.up * 0.1f;
        return Physics.Raycast(from, Vector3.down, groundCheck + 0.1f);
    }
}