using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicWander : MovementAlgorithm
{

    public KinematicWander(Transform character) : base(character)
    {

    }

    public override KinematicSteeringOutput getSteering(Transform character)
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();
        Vector3 direction = Vector3.zero;
        float rotation = 0f;

        // Move forward at max speed
        direction = character.forward * character.GetComponent<AgentController>().Speed;
        
        // Randomly change orientation
        rotation = generateRandomBinomial() * character.GetComponent<AgentController>().RotationSpeed; 
        Debug.Log(generateRandomBinomial());

        result.LinearVelocity = direction;
        result.AngularVelocity = rotation;

        return result;
    }
}
