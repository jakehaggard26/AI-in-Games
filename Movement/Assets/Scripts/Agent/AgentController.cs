using UnityEngine;

public class AgentController : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

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
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        kinematic = this.GetComponent<Kinematic>();

        movementAlgorithm = new KinematicFlee(this.transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        steeringOutput = movementAlgorithm.getSteering(target, this.transform);
        rb.velocity = steeringOutput.LinearVelocity;
    }
}
