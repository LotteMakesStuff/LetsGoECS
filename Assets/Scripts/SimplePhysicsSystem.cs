using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class SimplePhysicsSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        
        Entities.WithName("ApplyPhysics")
            .ForEach((ref Translation position, in Velocity velocity) =>
            {
                position.Value += velocity.Value * deltaTime;
            }).Run();
        
        Entities.WithName("CopyTransformToGameobject")
            .WithoutBurst()
            .ForEach((Transform transform, ref Translation position) =>
            {
                transform.position = position.Value;
            }).Run();
    }
}
