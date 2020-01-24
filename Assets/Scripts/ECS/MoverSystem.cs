using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class MoverSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation) =>
        {
            translation.Value.x += Random.Range(-2f, 2f) * Time.deltaTime;
            translation.Value.y += Random.Range(-2f, 2f) * Time.deltaTime;
            translation.Value.z += Random.Range(-2f, 2f) * Time.deltaTime;
        });
    }
}
