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

        if (target == null) { return result; }


        // Get the direction away from the target
        result.LinearVelocity = character.position - target.position;

        // Go in that direction at full speed
        result.LinearVelocity.Normalize();
        result.LinearVelocity *= character.GetComponent<AgentController>().Speed;

        // Look at target
        lookAtTarget(result.LinearVelocity);

        // For testing: Draw line to target
        Debug.DrawLine(character.position, target.position, Color.red);

        return result;
    }
}
