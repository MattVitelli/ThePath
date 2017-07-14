using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PathConstants {
    public static List<Vector3> GetPathPoints()
    {
        List<Vector3> path = new List<Vector3>();
        path.Add(new Vector3(-2, 0, -2));
        path.Add(new Vector3(-1.5f, 0, -1));
        path.Add(new Vector3(-1, 0, -0.5f));
        path.Add(new Vector3(-0.33f, 0, 0));
        path.Add(new Vector3(0, 0, 0.5f));
        path.Add(new Vector3(0.5f, 0, 1));
        path.Add(new Vector3(0.5f, 0, 2));
        path.Add(new Vector3(0.35f, 0, 3));
        path.Add(new Vector3(0, 0, 4));

        return path;
    }
}
