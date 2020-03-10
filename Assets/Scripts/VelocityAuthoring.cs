using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]
internal class VelocityAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float3 Value;
    
    // void Awake()
    // {
    //     Value = new float3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
    // }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Velocity(){Value = Value});
    }
}