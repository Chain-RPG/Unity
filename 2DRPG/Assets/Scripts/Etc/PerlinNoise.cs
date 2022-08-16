using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public int width = 256;
    LineRenderer renderer;
    Vector3[] noises;

    float time = 0;

    public float scale = 5;

    private void Start()
    {
        renderer = GetComponent<LineRenderer>();
        noises = new Vector3[width];
        renderer.positionCount = width;
    }

    private void Update()
    {
        Per();
        renderer.SetPositions(noises);
        time += Time.deltaTime * scale;
    }

    void Per()
    {
        Vector3 pos = gameObject.transform.position;
        Vector3 s = gameObject.transform.localScale;
        for (int x = 0; x < width; x++)
        {
            noises[x] = new Vector3 (pos.x - 1.275f + x * 0.01f * s.x,pos.y - 0.5f + Calc((float)x / width * scale, time) * s.y,pos.z);
        }
    }

    float Calc(float x, float y)
    {
        float f = Mathf.PerlinNoise(x, y);
        return f;
    }
}
