using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGeometry : MonoBehaviour {

    public Material PathMaterial;

    //The procedural mesh created by this script
    Mesh mesh;

	// Use this for initialization
	void Start () {
        //create the mesh + renderers + filters
        createMesh();

        //Issue an OnPathUpdated event
        List<Vector3> pathPoints = PathConstants.GetPathPoints();
        OnPathUpdated(pathPoints);
	}

    // Update is called once per frame
    void Update()
    {

    }

    //Appends a quad onto the vertex and index buffers
    void createQuad(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3, List<Vector3> verts, List<int> indices)
    {
        int numVerts = verts.Count;

        verts.Add(v0);
        verts.Add(v1);
        verts.Add(v2);
        verts.Add(v3);

        int idx_v0 = numVerts;
        int idx_v1 = numVerts + 1;
        int idx_v2 = numVerts + 2;
        int idx_v3 = numVerts + 3;

        //Add the first triangle
        indices.Add(idx_v0);
        indices.Add(idx_v2);
        indices.Add(idx_v3);

        //Add the second triangle
        indices.Add(idx_v3);
        indices.Add(idx_v1);
        indices.Add(idx_v0);
    }

    //Create a new procedural path when we get new points
    public void OnPathUpdated(List<Vector3> pathPoints)
    {
        List<Vector3> verts = new List<Vector3>();
        List<int> indices = new List<int>();

        //Appends a quad onto the vertex and index buffers
        createQuad(new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 1), verts, indices);

        //Clear the mesh and update it with the new vertex + index data
        mesh.Clear();
        mesh.SetVertices(verts);
        mesh.SetTriangles(indices, 0);
    }

    //Boilerplate code to create a mesh and render it
    void createMesh()
    {
        MeshRenderer mr = this.gameObject.AddComponent<MeshRenderer>();
        mr.material = PathMaterial;
        MeshFilter mf = this.gameObject.AddComponent<MeshFilter>();
        mf.sharedMesh = new Mesh();
        mesh = mf.sharedMesh;
    }
}
