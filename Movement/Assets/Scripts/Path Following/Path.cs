using System.Linq;
using UnityEngine;

public class Path : MonoBehaviour
{

    private PathNode[] path;

    // Start is called before the first frame update
    void Start()
    {
        path = FindObjectsOfType<PathNode>();

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

        // Reference for C# Array Slicing: https://stackoverflow.com/questions/406485/array-slices-in-c-sharp
        // PathNode[] coherence = @path[(param - 3)..(param - 1)];
        // coherence.Concat(@path[(param + 1)..(param + 3)]);

        // Get a subset of nodes around 'param', wrapping around the array if needed
        int subsetSize = 3;
        PathNode[] coherence = new PathNode[subsetSize];
        int pathLength = path.Length;
        for (int i = 0; i < subsetSize; i++)
        {
            // Skip the current param itself
            int idx = (param + i) % pathLength;
            coherence[i] = path[idx];
        }


        // Finds closest path node that is "near" the latest param
        foreach (PathNode p in coherence)
        {
            if (lastParam == p.parameter) { continue; }
            if (Vector3.Distance(position, p.transform.position) < minDistance)
            {
                minDistance = Vector3.Distance(position, p.transform.position);
                param = p.parameter;
            }

            break;
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
