using UnityEngine;

public class KinematicSteeringOutput
{
    #region Variables
    private Vector3 linearVelocity;
    private float angularVelocity;
    #endregion

    #region Properties
    public Vector3 LinearVelocity
    {
        get { return this.linearVelocity; }
        set { this.linearVelocity = value; }
    }

    public float AngularVelocity
    {
        get { return this.angularVelocity; }
        set { this.angularVelocity = value; }
    }
    #endregion

    #region Constructor
    public KinematicSteeringOutput()
    {
        this.linearVelocity = Vector3.zero;
        this.angularVelocity = 0f;
    }
    #endregion
}
