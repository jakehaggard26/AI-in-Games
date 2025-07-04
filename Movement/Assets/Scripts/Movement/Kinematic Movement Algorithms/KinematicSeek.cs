using UnityEngine;

public class KinematicSeek : MovementAlgorithm
{
    private Transform character;

    private
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public KinematicSeek(Transform character) : base(character)
    {

    }

    public override KinematicSteeringOutput getSteering(Transform target, Transform character)
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        if (target == null) { return result; }


        // Get the direction to the target
        result.LinearVelocity = target.position - character.position;

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
