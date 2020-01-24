using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;

public class ECS : MonoBehaviour
{
    [SerializeField] Mesh mesh;
    [SerializeField] Material material;

    private void Start()
    {
        EntityManager entityManager = World.Active.EntityManager;

        EntityArchetype entityArchetype = entityManager.CreateArchetype(
            typeof(LevelComponent),
            typeof(Translation),
            typeof(RenderMesh),
            typeof(LocalToWorld)
            );

        NativeArray<Entity> entities = new NativeArray<Entity>(10000, Allocator.Temp);

        entityManager.CreateEntity(entityArchetype, entities);

        for (int i = 0; i < entities.Length; i++)
        {
            Entity entity = entities[i];
            entityManager.SetComponentData(entity, new LevelComponent { level = Random.Range(0, 1000) });
            entityManager.SetSharedComponentData(entity, new RenderMesh {mesh = mesh, material = material });
        }
        entities.Dispose();
    }
}