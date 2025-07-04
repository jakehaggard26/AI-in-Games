using UnityEngine;

public class MovementAlgorithm
{
    Transform character;

    public MovementAlgorithm(Transform character)
    {
        this.character = character;
    }

    public virtual KinematicSteeringOutput getSteering(Transform target, Transform character)
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        return result;
    }

    public virtual void lookAtTarget(Vector3 direction)
    {
        Quaternion rotation = Quaternion.LookRotation(direction);
		character.rotation = Quaternion.Lerp(character.rotation, rotation, character.GetComponent<AgentController>().RotationSpeed * Time.deltaTime);
    }

    public virtual float newOrientation(float current, Vector3 velocity)
    {
        // if we have a velocity -> Return new orientaion
        if (velocity.magnitude > 0)
        {
            return Mathf.Atan2(-character.position.x, character.position.z);
        }

        // Otherwise, return current orientation
        else
        {
            return current;
        }
    }

    public virtual Vector3 calculateUpdatedOrientation(AgentController agent, float targetOrientation)
    {
        // Calculate the difference between the current and target orientation
        float currentY = character.eulerAngles.y;
        float targetY = targetOrientation * Mathf.Rad2Deg;

        float deltaY = Mathf.DeltaAngle(currentY, targetY);

        // Set angular velocity around the Y axis to rotate towards the target orientation
        Vector3 angularVelocity = Vector3.up * (deltaY * Mathf.Deg2Rad / Time.fixedDeltaTime);

        // Clamp the angular velocity to the desired rotation speed
        if (angularVelocity.magnitude > agent.RotationSpeed)
        {
            angularVelocity = angularVelocity.normalized * agent.RotationSpeed;
        }

        return angularVelocity;
    }
    

}
