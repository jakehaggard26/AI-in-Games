using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicArrival : MovementAlgorithm
{

    public KinematicArrival(Transform character) : base(character)
    {

    }

    public override KinematicSteeringOutput getSteering(Transform target, Transform character)
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();
        Vector3 direction = Vector3.zero;
        float distance = direction.magnitude;

        // Direction to target
        direction = target.position - character.position;

        // Distance to target
        distance = direction.magnitude;

        // Check to see if we are within the radius of satisfaction
        if (distance < character.GetComponent<AgentController>().RadiusOfSatisfaction)
        {
            return result;
        }

        // Otherwise check if we have exceeded our max speed
        if (character.GetComponent<Rigidbody>().velocity.magnitude > character.GetComponent<AgentController>().Speed)
        {
            direction.Normalize();
            direction *= character.GetComponent<AgentController>().Speed;
        }

        lookAtTarget(target.position);

        result.LinearVelocity = direction;
        result.AngularVelocity = 0f;

        return result;
    }
}
