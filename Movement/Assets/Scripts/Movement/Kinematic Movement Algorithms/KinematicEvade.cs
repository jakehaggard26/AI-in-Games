using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicEvade : MovementAlgorithm
{
    private float prediction;
    private float speed;

    public KinematicEvade(Transform character) : base(character)
    {

    }

    public override KinematicSteeringOutput getSteering(Transform target, Transform character)
    {

        Debug.Log("Evading?");
        KinematicSteeringOutput result = new KinematicSteeringOutput();
        AgentController agent = character.GetComponent<AgentController>();
        Vector3 predictedTarget = Vector3.zero;

        Vector3 direction = target.position + character.position;
        float distance = direction.magnitude;

        // Calculate speed
        speed = agent.Speed;

        // Check if speed gives a reasonable prediction time, if not use max predicition time
        if (speed <= distance / agent.MaxPredictionTime)
        {
            prediction = agent.MaxPredictionTime;
        }
        else
        {
            prediction = distance / speed;
        }

        // Calculate predicted target & seek it
        predictedTarget = target.position + (target.gameObject.GetComponent<Rigidbody>().velocity * prediction);
        result = new KinematicFlee(character).getSteering(predictedTarget, character);

        Debug.DrawLine(character.position, target.position, Color.blue);

        return result;
    }
}
