using UnityEngine;

public class KinematicMovementExample : MonoBehaviour
{

    [Header("Only Select One Value")]
    public bool isArrival;
    public bool isSeek;
    public bool isFlee;
    public bool isWander;
    private AgentController agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<AgentController>();

        if (isArrival) agent.MovementAlgorithm = new KinematicArrival(agent.transform);
        else if (isSeek) agent.MovementAlgorithm = new KinematicSeek(agent.transform);
        else if (isFlee) agent.MovementAlgorithm = new KinematicFlee(agent.transform);
        else if (isWander) agent.MovementAlgorithm = new KinematicWander(agent.transform);
        else return;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isArrival)
        {
            KinematicSteeringOutput result = agent.MovementAlgorithm.getSteering(agent.Target, agent.transform);
            agent.Rigidbody.velocity = result.LinearVelocity;
            agent.Rigidbody.angularVelocity = new Vector3(agent.Rigidbody.angularVelocity.x, result.AngularVelocity, agent.Rigidbody.angularVelocity.y);
        }

        else if (isSeek)
        {
            KinematicSteeringOutput result = agent.MovementAlgorithm.getSteering(agent.Target, agent.transform);
            agent.Rigidbody.velocity = result.LinearVelocity;
            agent.Rigidbody.angularVelocity = new Vector3(agent.Rigidbody.angularVelocity.x, result.AngularVelocity, agent.Rigidbody.angularVelocity.y);
        }

        else if (isWander)
        {
            KinematicSteeringOutput result = agent.MovementAlgorithm.getSteering(agent.transform);
            agent.Rigidbody.velocity = result.LinearVelocity;
            agent.Rigidbody.angularVelocity = new Vector3(agent.Rigidbody.angularVelocity.x, result.AngularVelocity, agent.Rigidbody.angularVelocity.y);
        }

        else if (isFlee)
        {
            KinematicSteeringOutput result = agent.MovementAlgorithm.getSteering(agent.Target, agent.transform);
            agent.Rigidbody.velocity = result.LinearVelocity;
            agent.Rigidbody.angularVelocity = new Vector3(agent.Rigidbody.angularVelocity.x, result.AngularVelocity, agent.Rigidbody.angularVelocity.y);
        }

        else
        {
            return;
        }
    }
}
