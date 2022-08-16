using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWave : MonoBehaviour
{
    Vector3[] vertex;
    WaveController controller;
    int resolution;

    int[] triangles;
    public GameObject Prefab;
    Mesh mesh;

    GameObject[] go;

    void Start()
    {
        controller = ((LogInScene)Managers.Scene.CurrentScene).Wave;
        resolution = controller.resolution;
        vertex = new Vector3[resolution * 2];
        mesh = new Mesh();
        gameObject.GetOrAddComponent<MeshFilter>().mesh = mesh;
        gameObject.GetOrAddComponent<MeshRenderer>().sharedMaterial = controller.HP;
        go = new GameObject[resolution * 2];
        for (int i = 0; i < resolution * 2; i++)
            go[i] = Instantiate(Prefab);
        triangles = new int[(resolution - 1) * 6];
        int vert = 0;
        int tris = 0;
        for (int i = 0; i < resolution - 1; i++)
        {
            triangles[tris + 0] = vert + 0;
            triangles[tris + 1] = vert + resolution;
            triangles[tris + 2] = vert + 1;
            triangles[tris + 3] = vert + 1;
            triangles[tris + 4] = vert + resolution;
            triangles[tris + 5] = vert + resolution + 1;
            vert++;
            tris += 6;
        }
        mesh.MarkDynamic();
    }

    void Update()
    {
        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        vertex = controller.Sin(transform.position);
        for (int x = 0; x < resolution; x++)
        {
            vertex[x + resolution] = new Vector3(transform.position.x - controller.width / 2f + x * controller.width / controller.resolution,
                transform.position.y - 0.7f, transform.position.z);
        }
        for (int i = 0; i < resolution * 2; i++)
        {
            go[i].transform.position = vertex[i];
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertex;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
