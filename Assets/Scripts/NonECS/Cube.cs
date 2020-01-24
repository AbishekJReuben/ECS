using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Random.Range(-2f, 2f) * Time.deltaTime, Random.Range(-2f, 2f) * Time.deltaTime, Random.Range(-2f, 2f) * Time.deltaTime);
    }
}
