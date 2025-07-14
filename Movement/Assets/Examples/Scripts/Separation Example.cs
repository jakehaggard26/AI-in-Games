using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SeparationExample : MonoBehaviour
{
    private MovementAlgorithm separationAlgorithm;
    private AgentController agent;

    private MovementAlgorithm seekAlgorithm;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<AgentController>();
        agent.Speed = Random.Range(1f, 5f);
        agent.DecayCoefficient = Random.Range(0.25f, 10f);
        agent.Threshold = 2.5f;

        separationAlgorithm = new Separation(agent.transform);
        seekAlgorithm = new KinematicSeek(agent.transform);
    }

    void FixedUpdate()
    {
        List<Collider> colliders = Physics.OverlapSphere(transform.position, agent.Threshold).ToList();
        KinematicSteeringOutput steeringOutput;

        foreach (Collider c in colliders)
        {
            if (c.gameObject.GetInstanceID() != agent.gameObject.GetInstanceID() && c.gameObject.layer != 6)
            {
                Debug.Log(agent.gameObject.name + " is separating from (" + c.gameObject.name + ")");
                steeringOutput = separationAlgorithm.getSteering(agent.transform);
                agent.Rigidbody.velocity = steeringOutput.LinearVelocity;
                // agent.Rigidbody.angularVelocity = new Vector3(agent.Rigidbody.angularVelocity.x, agent.Rigidbody.angularVelocity.y + steeringOutput.AngularVelocity, agent.Rigidbody.angularVelocity.z);
            }
            else
            {
                // Debug.Log(agent.gameObject.name + " is seeking (" + agent.Target.gameObject.name + ")");
                steeringOutput = seekAlgorithm.getSteering(agent.Target, agent.transform);
                agent.Rigidbody.velocity = steeringOutput.LinearVelocity;
            }
        }

    }

    void OnDrawGizmos()
    {
        if(agent != null) Gizmos.DrawWireSphere(agent.transform.position, agent.Threshold);
    }
}
