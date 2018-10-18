using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour {

    public float Radius;
    public float Height;
    public int TotalHexes;

    public bool ReDraw;

    List<Assets.HexagonalPrism> hexList;

    int totalHexesRendered;
    //int currentHexesRendered;

    bool stupid = false;

    // Use this for initializatiom
    void Start() {
        hexList = new List<Assets.HexagonalPrism>();
    }
	
	// Update is called once per frame
	void Update () {
		if (ReDraw) {
            ReDraw = false;
            totalHexesRendered = 0;
            for (int i = 0; i < hexList.Count; i++) {
                Destroy(hexList[i].GameObject);
            }
        }

        while(totalHexesRendered < TotalHexes) {
            totalHexesRendered++;
            DrawHex();
        }

	}

    void DrawHex() {
        Assets.HexagonalPrism hex = new Assets.HexagonalPrism(Radius, Height, transform.position, Resources.Load <Material>("BoxMat"), Resources.Load<PhysicMaterial>("NoStuck"));
    }

    void LateUpdate() {
        if(stupid = false) {
            stupid = true;
            hexList[0].GetComponent<MeshCollider>().enabled = false;
            hexList[0].GetComponent<MeshCollider>().enabled = true;
        }
    }
}
