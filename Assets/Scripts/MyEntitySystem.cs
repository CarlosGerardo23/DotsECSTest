using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
using UnityEngine;
[BurstCompile]
public partial struct MyEntitySystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        foreach (RefRW<MyEntity> myEntity in SystemAPI.Query<RefRW<MyEntity>>())
        {
            Debug.Log($"My Entity Position: {myEntity.ValueRO.position}");
            Vector3 newPosition = Vector3.zero;
            myEntity.ValueRW.position = newPosition;
             Debug.Log($"My Entity Position: {myEntity.ValueRO.position}");
        }
    }
}
