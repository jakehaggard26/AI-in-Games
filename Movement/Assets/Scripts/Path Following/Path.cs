// WIP
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Path : MonoBehaviour
{

    private PathNode[] path;

    public PathNode[] getPath()
    {
        return this.path;
    }

    // Start is called before the first frame update
    void Start()
    {
        path = FindObjectsOfType<PathNode>().OrderBy(node => node.getNumberInName()).ToArray();
        Debug.Log(path);

        for (int i = 0; i < path.Length; i++)
        {
            path[i].parameter = i;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getParameter(Vector3 position, int lastParam)
    {
        int param = lastParam;
        float minDistance = Mathf.Infinity;
        float dist = 0f;

        // Reference for C# Array Slicing: https://stackoverflow.com/questions/406485/array-slices-in-c-sharp
        // PathNode[] coherence = @path[(param - 3)..(param - 1)];
        // coherence.Concat(@path[(param + 1)..(param + 3)]);

        // Get nodes beyond our current node
        List<PathNode> coherenceList = new List<PathNode>();
        int start = Mathf.Max(0, param - 2);
        int end = Mathf.Min(path.Length - 1, param + 2);

        for (int i = start; i <= end; i++)
        {
            coherenceList.Add(path[i]);
        }

        // foreach (PathNode c in coherence)
        foreach (PathNode c in coherenceList)
        {
            dist = Vector3.Distance(position, c.transform.position);

            if (dist < minDistance)
            {
                Debug.Log("Old Min: " + minDistance);
                Debug.Log("New Min: " + dist);
                param = c.parameter;
                minDistance = dist;
            }
        }
        
        return param;
    }

    public Vector3 getPosition(float param)
    {
        Vector3 position = Vector3.zero;

        position = path[(int)param].transform.position;

        return position;
    }
}
