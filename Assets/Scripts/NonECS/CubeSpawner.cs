using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cube;

    private void Start()
    {
        for (int i = 0; i < 10000; i++)
        {
            Instantiate(cube);
        }
    }
}
