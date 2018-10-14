using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour {

    Mesh mesh;

    public Material mat;

    public float Radius;
    public float Width;
    public float Height;

    Assets.HexagonalPrism hex;

    public bool ReDraw;

    // Use this for initializatiom
    void Start() {
        ReDraw = false;
        mesh = new Mesh();
        ReDrawHex();
    }
	
	// Update is called once per frame
	void Update () {
		if (ReDraw) {
            ReDraw = false;
            ReDrawHex();
        }
	}

    void ReDrawHex() {
        hex = new Assets.HexagonalPrism(Radius, Width, Height, Vector3.zero);

        mesh.vertices = hex.Vertices;

        mesh.triangles = hex.Triangles;

        GetComponent<MeshRenderer>().material = mat;

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
