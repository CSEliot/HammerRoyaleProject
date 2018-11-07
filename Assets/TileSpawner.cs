using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {

    public GameObject HexagonalPrism;
    public float Radius;
    public float Height;
    public int TotalHexes;

    public bool ReDraw;

    List<GameObject> Tiles;

    int totalHexesRendered;
    //int currentHexesRendered;

    // Use this for initializatiom
    void Start() {
        Tiles = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
		if (ReDraw) {
            ReDraw = false;
            totalHexesRendered = 0;
            for (int i = 0; i < Tiles.Count; i++) {
                Destroy(Tiles[i]);
                Tiles.RemoveAt(i);
            }
        }

        while(totalHexesRendered < TotalHexes) {
            totalHexesRendered++;
            DrawHex();
        }

	}

    void DrawHex() {
        GameObject hex = Instantiate(HexagonalPrism, transform.position, Quaternion.Euler(Vector3.zero));
        hex.GetComponent<HexagonalPrism>().Shape = new HexagonalPrism.HexShape(Radius, Height);
        Tiles.Add(hex);
    }
}
