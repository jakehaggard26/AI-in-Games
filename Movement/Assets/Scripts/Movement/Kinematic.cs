using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
    #region Variables
    private float orientation;
    private Vector3 velocity;
    private float rotation;

    private Rigidbody rb;
    private AgentController agent;
    #endregion

    #region Properties
    public Vector3 Position
    {
        get { return this.transform.position; }
    }

    public float Orientation
    {
        get { return Mathf.Atan2(-this.transform.position.x, this.transform.position.z); }
    }

    public Vector3 Velocity
    {
        get { return rb.velocity; }
        set { rb.velocity = value; }
    }

    public Vector3 Rotation
    {
        get { return rb.angularVelocity; }
        set { rb.angularVelocity = value; }
    }
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        agent = this.GetComponent<AgentController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region Custom Methods
    public float getRotationSpeed()
    {
        return rb.angularVelocity.magnitude;
    }


    
    #endregion

}
