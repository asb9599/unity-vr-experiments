using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererInfo : MonoBehaviour
{

    // Private Variables
    private MeshRenderer meshRenderer;
    // Properties
    public Vector3 meshSize { get { return meshRenderer.bounds.size; } }
    public Vector3 min { get { return meshRenderer.bounds.min; } }
    public Vector3 max { get { return meshRenderer.bounds.max; } }
    public Vector3 center { get { return meshRenderer.bounds.center; } }
    public float xLength { get { return max.x - min.x; } }
    public float yLength { get { return max.y - min.y; } }
    public float zLength { get { return max.z - min.z; } }
    // Use this for initialization
    void Start ()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        Debug.Log("Z Length: " + zLength);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
