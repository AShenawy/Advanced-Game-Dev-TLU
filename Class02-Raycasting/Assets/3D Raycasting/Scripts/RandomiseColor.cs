using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseColor : MonoBehaviour
{
    MeshRenderer meshRender;

    // Start is called before the first frame update
    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    public void Randomise()
    {
        meshRender.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
