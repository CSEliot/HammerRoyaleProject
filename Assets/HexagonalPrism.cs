using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Doesn't support rotation. Top Center = Position.
/// </summary>
class HexagonalPrism:MonoBehaviour {

    public struct HexShape {
        public float Radius;
        public float Height;

        public HexShape(float Radius, float Height) {
            this.Radius = Radius;
            this.Height = Height;
        }
    }

    //public references
    public HexShape Shape;

    //unity privates
    MeshCollider meshCollider;
    MeshRenderer meshRenderer;
    Mesh mesh;
    MeshFilter meshFilter;
    
    //obj privates
    Vector3[] vertices;
    int[] triangles;

    //static
    static Vector3 _center = Vector3.zero;

    void Start() {
        meshCollider = gameObject.GetComponent<MeshCollider>();
        meshRenderer = gameObject.GetComponent <MeshRenderer>();
        meshFilter = gameObject.GetComponent <MeshFilter>();
        mesh = new Mesh();

        setDimensions();
    }

    void setDimensions () {
        
        float yMax = _center.y + Shape.Height;
        float yMin = _center.y;

        vertices = new Vector3[] {
            new Vector3(0, yMax, 0), //TopCenter
            new Vector3(Shape.Radius * Mathf.Cos(Mathf.Deg2Rad*0f),  yMax, Shape.Radius * Mathf.Sin(Mathf.Deg2Rad*0f  )),//Top1
            new Vector3(Shape.Radius * Mathf.Cos(Mathf.Deg2Rad*60f), yMax, Shape.Radius * Mathf.Sin(Mathf.Deg2Rad*60f )),//Top2
            new Vector3(Shape.Radius * Mathf.Cos(Mathf.Deg2Rad*120f),yMax, Shape.Radius * Mathf.Sin(Mathf.Deg2Rad*120f)),//Top3
            new Vector3(Shape.Radius * Mathf.Cos(Mathf.Deg2Rad*180f),yMax, Shape.Radius * Mathf.Sin(Mathf.Deg2Rad*180f)),//Top4
            new Vector3(Shape.Radius * Mathf.Cos(Mathf.Deg2Rad*240f),yMax, Shape.Radius * Mathf.Sin(Mathf.Deg2Rad*240f)),//Top5
            new Vector3(Shape.Radius * Mathf.Cos(Mathf.Deg2Rad*300f),yMax, Shape.Radius * Mathf.Sin(Mathf.Deg2Rad*300f)),//Top6
            new Vector3(Shape.Radius * Mathf.Cos(Mathf.Deg2Rad*0f),  yMin, Shape.Radius * Mathf.Sin(Mathf.Deg2Rad*0f  )),//Bottom1
            new Vector3(Shape.Radius * Mathf.Cos(Mathf.Deg2Rad*60f), yMin, Shape.Radius * Mathf.Sin(Mathf.Deg2Rad*60f )),//Bottom2
            new Vector3(Shape.Radius * Mathf.Cos(Mathf.Deg2Rad*120f),yMin, Shape.Radius * Mathf.Sin(Mathf.Deg2Rad*120f)),//Bottom3
            new Vector3(Shape.Radius * Mathf.Cos(Mathf.Deg2Rad*180f),yMin, Shape.Radius * Mathf.Sin(Mathf.Deg2Rad*180f)),//Bottom4
            new Vector3(Shape.Radius * Mathf.Cos(Mathf.Deg2Rad*240f),yMin, Shape.Radius * Mathf.Sin(Mathf.Deg2Rad*240f)),//Bottom5
            new Vector3(Shape.Radius * Mathf.Cos(Mathf.Deg2Rad*300f),yMin, Shape.Radius * Mathf.Sin(Mathf.Deg2Rad*300f)),//Bottom6
            new Vector3(0, yMin, 0) //BottomCenter 
        };

        triangles = new int[] {  0,  2,  1,
                                    0,  3,  2,
                                    0,  4,  3,
                                    0,  5,  4,
                                    0,  6,  5,
                                    0,  1,  6,
                                    1,  8,  7,
                                    1,  2,  8,
                                    2,  9,  8,
                                    2,  3,  9,
                                    3, 10,  9,
                                    3,  4, 10,
                                    4, 11, 10,
                                    4,  5, 11,
                                    5, 12, 11,
                                    5,  6, 12,
                                    6,  7, 12,
                                    6,  1,  7,
                                13,  7,  8,
                                13, 12,  7,
                                13, 11, 12,
                                13, 10, 11,
                                13,  9, 10,
                                13,  8,  9
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;
    }
}

