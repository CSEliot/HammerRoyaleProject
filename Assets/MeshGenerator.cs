using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour {

    public GameObject HexObject;
    public float Radius;
    public float Height;
    public int TotalHexes;

    public bool ReDraw;

    List<HexagonalPrism> hexList;

    int totalHexesRendered;
    //int currentHexesRendered;

    bool stupid = false;

    // Use this for initializatiom
    void Start() {
        hexList = new List<HexagonalPrism>();
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
        HexagonalPrism hex = new HexagonalPrism(Radius, Height, transform.position, HexObject);
        hexList.Add(hex);
    }
}
