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

    public float newOrientation(Vector3 velocity)
    {
        // if we have a velocity -> Return new orientaion
        if (velocity.magnitude > 0)
        {
            return Mathf.Atan2(-this.transform.position.x, this.transform.position.z);
        }

        // Otherwise, return current orientation
        else
        {
            return this.orientation;
        }
    }

    public Vector3 calculateUpdatedOrientation(float targetOrientation)
    {
        // Calculate the difference between the current and target orientation
        float currentY = this.transform.eulerAngles.y;
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
    
    #endregion

}
