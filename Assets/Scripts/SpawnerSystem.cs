using Unity.Entities;
using Unity.Burst;
using Unity.Transforms;
using UnityEngine;
[BurstCompile]
public partial struct SpawnerSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (RefRW<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
        {
            ProcessSpawner(ref state, spawner);
        }
    }
    private void ProcessSpawner(ref SystemState state, RefRW<Spawner> spawner)
    {
        if (spawner.ValueRO.nextSpawnTime < SystemAPI.Time.ElapsedTime)
        {
            Entity entity = state.EntityManager.Instantiate(spawner.ValueRO.prefab);
            state.EntityManager.SetComponentData(entity,
            LocalTransform.FromPosition(spawner.ValueRO.spawnPosition));
            spawner.ValueRW.nextSpawnTime = (float)SystemAPI.Time.ElapsedTime + spawner.ValueRO.spawnRate;
        }
    }
}
