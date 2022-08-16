using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour 
{
    public int resolution = 25;
    public float width = 2;
    public float height = 0.05f;

    public Material HP;

    float time = 0;

    public float scale = 5;

    private void Start()
    {
        HP = Managers.Resource.Load<Material>("Material/HPMaterial");
    }

    private void Update()
    {
        if (time < Mathf.PI * 2)
            time += Time.deltaTime * scale;
        else
            time = 0;

    }

    public Vector3[] Sin(Vector3 pos)
    {
        Vector3[] noises = new Vector3[resolution * 2];
        for (int x = 0; x < resolution; x++)
        {
            noises[x] = new Vector3(pos.x - width / 2f + x * width / resolution, pos.y - height / 2f + Mathf.Sin(time + x) * height, pos.z);
        }
        return noises;
    }
}
