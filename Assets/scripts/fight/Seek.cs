using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : AgentBehavior
{
    public LayerMask obstacleLayer; // Layer mask for obstacles
    public float avoidRadius = 5f; // Radius to detect obstacles
    public float avoidWeight = 5f; // Weight to adjust the strength of avoidance

    // Move towards a target with obstacle avoidance
    public override steering GetSteering()
    {
        steering steer = new steering();

        // Seek behavior
        steer.linear = target.transform.position - transform.position;
        steer.linear.Normalize();
        steer.linear = steer.linear * agent.maxAccel;

        // Obstacle avoidance
        RaycastHit hit;
        if (CheckObstacle(out hit))
        {
            steer.linear += AvoidObstacle(hit.point) * avoidWeight;
        }

        return steer;
    }

    // Check for obstacles in the path
    private bool CheckObstacle(out RaycastHit hit)
    {
        // Cast a ray forward to detect obstacles on the specific layer
        return Physics.Raycast(transform.position, transform.forward, out hit, avoidRadius, obstacleLayer);
    }

    // Calculate avoidance steering based on the obstacle position
    private Vector3 AvoidObstacle(Vector3 obstaclePos)
    {
        Vector3 avoidVector = obstaclePos - transform.position;
        avoidVector.Normalize();
        avoidVector *= agent.maxAccel;
        return avoidVector;
    }
}
