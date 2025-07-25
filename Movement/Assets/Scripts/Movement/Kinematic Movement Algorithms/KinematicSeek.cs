using UnityEngine;

public class KinematicSeek : MovementAlgorithm
{
    public KinematicSeek(Transform character) : base(character)
    {

    }

    public override KinematicSteeringOutput getSteering(Transform target, Transform character)
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();
        Vector3 direction = Vector3.zero;

        if (target == null) { return result; }
        // Get the direction to the target
        direction = target.position - character.position;

        // Go in that direction at full speed
        direction.Normalize();
        direction *= character.GetComponent<AgentController>().Speed;

        // Look at target
        lookAtTarget(direction);

        // For testing: Draw line to target
        Debug.DrawLine(character.position, target.position, Color.red);

        // Store direction in Steering Output
        result.LinearVelocity = direction;

        return result;
    }

     public override KinematicSteeringOutput getSteering(Vector3 target, Transform character)
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();
        Vector3 direction = Vector3.zero;

        if (target == null) { return result; }
        // Get the direction to the target
        direction = target - character.position;

        // Go in that direction at full speed
        direction.Normalize();
        direction *= character.GetComponent<AgentController>().Speed;

        // Look at target
        lookAtTarget(direction);

        // For testing: Draw line to target
        Debug.DrawLine(character.position, (character.position + direction) ,Color.red);

        // Store direction in Steering Output
        result.LinearVelocity = direction;

        return result;
    }
    

}
