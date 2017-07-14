using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPathPoints : MonoBehaviour {
    
    void generatePathPoint(Vector3 pt, int pt_idx)
    {
        GameObject ptGO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ptGO.transform.position = pt;
        ptGO.transform.localScale = Vector3.one * 0.1f;
        ptGO.GetComponent<Renderer>().material.color = Color.red;
        ptGO.transform.parent = dummyParent.transform;

        GameObject ptGOText = new GameObject();
        ptGOText.transform.position = pt;
        ptGOText.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
        ptGOText.transform.parent = dummyParent.transform;
        TextMesh text = ptGOText.AddComponent<TextMesh>();
        text.text = "P" + pt_idx;
        text.color = Color.black;
        text.characterSize = 0.1f;
    }

    GameObject dummyParent;
	// Use this for initialization
	void Start () {

        dummyParent = new GameObject("Debug Points");
        dummyParent.transform.parent = this.transform.parent;
        List<Vector3> pts = PathConstants.GetPathPoints();
        for(int p_idx = 0; p_idx < pts.Count; p_idx++)
        {
            generatePathPoint(pts[p_idx], p_idx);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
