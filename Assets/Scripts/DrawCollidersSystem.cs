using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class DrawCollidersSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Debug.DrawLine(new Vector3(-5,-5, 0), new Vector3(5,-5, 0), Color.red);
    }
}
