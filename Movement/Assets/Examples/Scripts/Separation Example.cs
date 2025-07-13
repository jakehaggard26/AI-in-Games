using UnityEngine;

public class SeparationExample : MonoBehaviour
{
    private MovementAlgorithm algorithm;
    private AgentController agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<AgentController>();
        algorithm = new Separation(agent.transform);    
    }

    void FixedUpdate()
    {
        KinematicSteeringOutput steeringOutput = algorithm.getSteering(agent.transform);
        Debug.Log(agent.gameObject.name + ": "+ steeringOutput.LinearVelocity);
        agent.Rigidbody.velocity = steeringOutput.LinearVelocity;
        // agent.Rigidbody.angularVelocity = new Vector3(agent.Rigidbody.angularVelocity.x, agent.Rigidbody.angularVelocity.y + steeringOutput.AngularVelocity, agent.Rigidbody.angularVelocity.z);
    }

    void OnDrawGizmos()
    {
        if(agent != null) Gizmos.DrawWireSphere(agent.transform.position, agent.Threshold);
    }
}
