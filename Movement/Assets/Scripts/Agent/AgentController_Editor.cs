using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AgentController))]
public class AgentController_Editor : Editor
{

    private AgentController agent;

    private void OnEnable()
    {
        agent = (AgentController)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        string message = "";
        message += "Agent Traits\n--------------------------------------------\n";
        message += "Agent Name: " + agent.gameObject.name + "\n";
        if (agent.Target != null)
        {
            message += "Target Position: " + agent.Target.position + "\n";
        }
        message += "Agent Position: " + agent.transform.position + "\n";
        message += "Agent Speed: " + agent.Speed + "\n";
        message += "Agent Rotation Speed: " + agent.RotationSpeed + "\n";
        if (agent.Kinematic == null)
        {
            message += "Kinematic is Null" + "\n";
        }
        else
        {
            message += "Agent Orientation: " + agent.Kinematic.Orientation + "\n";
            message += "Agent Linear Velocity: " + agent.Kinematic.Velocity + "\n";
            message += "Agent Angular Velocity: " + agent.Kinematic.Rotation + "\n";
        }

        if (agent.MovementAlgorithm == null)
        {
            message += "Movement Algorithm is null\n";
        }
        else
        {
            message += "Movement Algorithm: " + agent.MovementAlgorithm.ToString() + "\n";
        }

        GUILayout.Space(10);
        EditorGUILayout.TextArea(message, GUILayout.Height(200));
        Repaint();
    }
}
