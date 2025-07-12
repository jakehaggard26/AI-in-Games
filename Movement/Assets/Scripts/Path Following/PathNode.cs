using UnityEngine;
using System.Collections.Generic;
using System;

public class PathNode : MonoBehaviour
{
    public int parameter;

    // Helps with sorting the Path Nodes properly. Sorted by string name value and not order they were added in 
    public int getNumberInName()
    {
        int num = -1;

        if (this.transform.name.Length == 13)
        {
            Int32.TryParse(this.transform.name.Substring(11, 1), out num);
        }
        else if (this.transform.name.Length == 14)
        {
            Int32.TryParse(this.transform.name.Substring(11, 2), out num);
        }
        else
        {
            return int.MinValue;
        }

        return num;
    }
}

public class PathNodeComparer : IComparer<PathNode>
{
    public int Compare(PathNode x, PathNode y)
    {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;
        return string.Compare(x.transform.name, y.transform.name, System.StringComparison.Ordinal);
    }
}
