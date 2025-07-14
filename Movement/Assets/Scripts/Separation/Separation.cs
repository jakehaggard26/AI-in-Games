using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Separation : MovementAlgorithm
{

    private AgentController agent;
    

    public Separation(Transform character) : base(character)
    {
        agent = character.gameObject.GetComponent<AgentController>();
        

        if (agent.Threshold <= 0) agent.Threshold = 1.5f;
        if (agent.DecayCoefficient <= 0) agent.DecayCoefficient = 0.5f;
    }


    public override KinematicSteeringOutput getSteering(Transform character)
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();
        AgentController[] targets = GameObject.FindObjectsOfType<AgentController>();
        Vector3 direction;
        float distance;
        float strength;




        foreach (AgentController target in targets)
        {
            // Skip checking itself
            if (target.gameObject.GetInstanceID() == character.gameObject.GetInstanceID()) continue;

            direction = character.position - target.transform.position;
            distance = direction.magnitude;

            // https://docs.unity3d.com/ScriptReference/Bounds-size.html
            if (distance < agent.Threshold + agent.GetComponent<CapsuleCollider>().bounds.size.x)
            {
                Debug.Log(character.gameObject.name + " is avoiding " + target.gameObject.name);

                // Calculate strength of repulsion aka separation
                // A higher decay coefficient = A stronger separation strength, the opposite is true for a smaller decayCoefficient
                strength = Mathf.Min(agent.DecayCoefficient / (distance * distance), agent.MaxAcceleration);

                Debug.Log(agent.gameObject.name + "'s Calculation: " + agent.DecayCoefficient / (distance * distance));

                direction.Normalize();
                result.LinearVelocity = strength * direction;
            }
        }

        return result;
    }
}
