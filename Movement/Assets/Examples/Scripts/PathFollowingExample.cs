using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowingExample : MonoBehaviour
{
    private AgentController agent;
    private Kinematic kinematic;
    private Rigidbody rb;

    private KinematicSteeringOutput steeringOutput;
    private MovementAlgorithm movementAlgorithm;

    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<AgentController>();
        rb = agent.GetComponent<Rigidbody>();
        kinematic = agent.GetComponent<Kinematic>();

        steeringOutput = new KinematicSteeringOutput();
        movementAlgorithm = new PathFollowing(this.transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        steeringOutput = movementAlgorithm.getSteering(this.transform);
        
        rb.velocity = steeringOutput.LinearVelocity;
        // rb.angularVelocity = new Vector3(rb.angularVelocity.x, rb.angularVelocity.y + steeringOutput.AngularVelocity, rb.angularVelocity.z);
    }
}
