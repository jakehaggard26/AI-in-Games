using UnityEngine;

public class AgentController : MonoBehaviour
{

    
    

    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float radiusOfSatisfaction;
    [SerializeField] private float timeToTarget;

    [SerializeField] private Path path;

    private KinematicSteeringOutput steeringOutput;

    private Rigidbody rb;
    private Kinematic kinematic;
    private MovementAlgorithm movementAlgorithm;

    #region Properties
    public float Speed
    {
        get { return this.speed; }
    }

    public float RotationSpeed
    {
        get { return this.rotationSpeed; }   
    }

    public float RadiusOfSatisfaction
    {
        get { return this.radiusOfSatisfaction; }
        set { this.radiusOfSatisfaction = value; }
    }

    public float TimeToTarget
    {
        get { return this.timeToTarget; }
        set { this.timeToTarget = value; }
    }

    public Transform Target
    {
        get { return this.target; }
        set { this.target = value; }
    }

    public Kinematic Kinematic
    {
        get { return this.kinematic; }
    }

    public Rigidbody Rigidbody
    {
        get { return this.rb; }
    }

    public MovementAlgorithm MovementAlgorithm
    {
        get { return this.movementAlgorithm; }
        set { this.movementAlgorithm = value; }
    }

    public Path Path
    {
        get { return this.path; }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        kinematic = this.GetComponent<Kinematic>();

        // steeringOutput = new KinematicSteeringOutput();
        // movementAlgorithm = new PathFollowing(this.transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // steeringOutput = movementAlgorithm.getSteering(this.transform);
        
        // rb.velocity = steeringOutput.LinearVelocity;
        // rb.angularVelocity = new Vector3(rb.angularVelocity.x, rb.angularVelocity.y + steeringOutput.AngularVelocity, rb.angularVelocity.z);
    }
}
