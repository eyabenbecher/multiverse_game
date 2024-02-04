using UnityEngine;

public class Agent : MonoBehaviour
{
    public float maxSpeed = 1.0f;
    public float trueMaxSpeed;
    public float maxAccel = 30.0f;

    public float orientation = 0.0f;
    public float rotation;
    public Vector3 velocity;
    protected steering steer;

    public float maxRotation = 45.0f;
    public float maxAngularAccel = 45.0f;

    public Transform target;  // Reference to the target transform
    public float stopDistance = 20.0f;  // Distance threshold to stop at the target

    void Start()
    {
        InitializeAgent();
    }

    void InitializeAgent()
    {
        velocity = Vector3.zero;
        steer = new steering();
        trueMaxSpeed = maxSpeed;
    }

    public void SetSteering(steering steer, float weight)
    {
        this.steer.linear += (weight * steer.linear);
        this.steer.angular += (weight * steer.angular);
    }

    // Update the agent's orientation and transform based on the target
    public virtual void Update()
    {
        if (target != null)
        {
            Vector3 toTarget = target.position - transform.position;

            // Check if the agent is close enough to the target to stop
            if (toTarget.sqrMagnitude < stopDistance * stopDistance)
            {
                velocity = Vector3.zero;
            }
            else
            {
                // Move towards the target
                velocity = toTarget.normalized * maxSpeed;

                // Update orientation towards the target
                UpdateOrientationTowardsTarget();
            }
        }

        Vector3 displacement = velocity * Time.deltaTime;
        displacement.y = 0;

        transform.Translate(displacement, Space.World);

        // Rotate towards the target only if not at the target
        if (velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, orientation, 0), maxRotation * Time.deltaTime);
        }
    }

    // Update movement for the next frame
    public virtual void LateUpdate()
    {
        UpdateVelocityAndRotation();

        // Speed limiting
        if (velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }

        // Reset velocity if no linear steering
        if (steer.linear.magnitude == 0.0f)
        {
            velocity = Vector3.zero;
        }

        steer = new steering();
    }

    // Orient the agent towards the target
    void UpdateOrientationTowardsTarget()
    {
        Vector3 toTarget = target.position - transform.position;
        toTarget.y = 0;

        float targetOrientation = Mathf.Atan2(toTarget.x, toTarget.z) * Mathf.Rad2Deg;
        orientation = Mathf.LerpAngle(orientation, targetOrientation, Time.deltaTime * maxRotation);

        // Limit orientation between 0 and 360
        orientation = Mathf.Repeat(orientation, 360.0f);
    }

    // Update velocity and rotation based on steering
    void UpdateVelocityAndRotation()
    {
        velocity += steer.linear * Time.deltaTime;
        rotation += steer.angular * Time.deltaTime;
    }

    // Used for speed matching when traveling in groups
    public void SpeedReset()
    {
        maxSpeed = trueMaxSpeed;
    }
}
