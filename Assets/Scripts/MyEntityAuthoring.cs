using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class MyEntityAuthoring : MonoBehaviour
{
   
}

class MyEntityBaker: Baker<MyEntityAuthoring>
{
    public override void Bake(MyEntityAuthoring authoring)
    {
        var entity= GetEntity(TransformUsageFlags.None);
        AddComponent(entity,new MyEntity
        {
            position = authoring.transform.position,
          
        });
    }
}