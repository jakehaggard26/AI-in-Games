using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicFlee : MovementAlgorithm
{
    public KinematicFlee(Transform character) : base(character)
    {

    }

    public override KinematicSteeringOutput getSteering(Transform target, Transform character)
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();
        Vector3 direction = Vector3.zero;

        if (target == null) { return result; }
        // Get the direction away from the target
        direction = character.position - target.position;

        // Go in that direction at full speed
        direction.Normalize();
        direction *= character.GetComponent<AgentController>().Speed;

        // Look at target
        lookAtTarget(direction);

        // For testing: Draw line to target
        Debug.DrawLine(character.position, target.position, Color.red);

        // For testing: Draw line to calculated direction
        Debug.DrawLine(character.position, character.position + direction, Color.red);

        // Store direction in Steering Output
        result.LinearVelocity = direction;

        return result;
    }

    public override KinematicSteeringOutput getSteering(Vector3 target, Transform character)
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();
        Vector3 direction = Vector3.zero;

        if (target == null) { return result; }
        // Get the direction away from the target
        direction = character.position - target;

        // Go in that direction at full speed
        direction.Normalize();
        direction *= character.GetComponent<AgentController>().Speed;

        // Look at target
        lookAtTarget(direction);

        // For testing: Draw line to target
        Debug.DrawLine(character.position, target, Color.red);

        // For testing: Draw line to calculated direction
        Debug.DrawLine(character.position, character.position + direction, Color.red);

        // Store direction in Steering Output
        result.LinearVelocity = direction;

        return result;
    }
}
