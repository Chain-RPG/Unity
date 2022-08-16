using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adadas : MonoBehaviour
{
    Mesh mesh;
    int[] triangles = new int[3];
    Vector3[] vertex = { new Vector3(0,0,1), new Vector3(1,0,1),new Vector3(1, 1, 1)};

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        gameObject.GetOrAddComponent<MeshFilter>().mesh = mesh;
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
        mesh.Clear();
        mesh.vertices = vertex;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public float width = 1;
    //public float height = 1;

    //public void Start()
    //{
    //    MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
    //    meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

    //    MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

    //    Mesh mesh = new Mesh();

    //    Vector3[] vertices = new Vector3[4]
    //    {
    //        new Vector3(0, 0, 0),
    //        new Vector3(width, 0, 0),
    //        new Vector3(0, height, 0),
    //        new Vector3(width, height, 0)
    //    };
    //    mesh.vertices = vertices;

    //    int[] tris = new int[6]
    //    {
    //        // lower left triangle
    //        0, 2, 1,
    //        // upper right triangle
    //        2, 3, 1
    //    };
    //    mesh.triangles = tris;

    //    Vector3[] normals = new Vector3[4]
    //    {
    //        -Vector3.forward,
    //        -Vector3.forward,
    //        -Vector3.forward,
    //        -Vector3.forward
    //    };
    //    mesh.normals = normals;

    //    Vector2[] uv = new Vector2[4]
    //    {
    //        new Vector2(0, 0),
    //        new Vector2(1, 0),
    //        new Vector2(0, 1),
    //        new Vector2(1, 1)
    //    };
    //    mesh.uv = uv;

    //    meshFilter.mesh = mesh;
    //}
}
