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
        // Debug.Log(path);
        // Debug.Log(path.Length);

        for (int i = 0; i < path.Length; i++)
        {
            path[i].parameter = i;
            // Debug.Log(i + ": " + path[i].parameter);
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


        int pathLength = path.Length;
        if (lastParam < 0 || lastParam >= pathLength)
            lastParam = 0;

        // Define how many nodes to check on either side of lastParam
        int window = 2;


        List<PathNode> coherence = new List<PathNode>();

        // From our last parameter n, we look at n-2,n-1,n,n+1,n+2
        for (int offset = -window; offset <= window; offset++)
        {
            // Slices the collection in a circular manner
            int idx = (lastParam + offset + pathLength) % pathLength;
            coherence.Add(path[idx]);
        }

        foreach (PathNode c in coherence)
        {
            dist = Vector3.Distance(position, c.transform.position);
            // Debug.Log("********\t" + c.getNumberInName() + "\t********");

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
