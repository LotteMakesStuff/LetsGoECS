using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class SimplePhysicsSystem : SystemBase
{
    const float floor = -5f;
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        
        Entities.WithName("ApplyGravity")
            .ForEach((ref Velocity velocity) => { velocity.Value += (float3) Physics.gravity * deltaTime; }).Run();
            
        
        Entities.WithName("ApplyPhysics")
            .ForEach((ref Translation position, in Velocity velocity) =>
            {
                position.Value += velocity.Value * deltaTime;
            }).Run();
        
        Entities.WithName("ApplyFloorCollision")
            .ForEach((ref Translation position, ref Velocity velocity) =>
            {
                if (position.Value.y < floor + 0.5f)
                {
                    position.Value.y = floor + 0.5f;
                    velocity.Value = math.reflect(velocity.Value, math.up())/1.25f;
                }
            }).Run();
        
        Entities.WithName("CopyTransformToGameobject")
            .WithoutBurst()
            .ForEach((Transform transform, ref Translation position) =>
            {
                transform.position = position.Value;
            }).Run();
    }
}
