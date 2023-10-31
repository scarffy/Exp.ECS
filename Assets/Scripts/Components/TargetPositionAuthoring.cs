using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECSProgramming
{
    public class TargetPositionAuthoring : MonoBehaviour
    {
        public float3 value;
    }
    
    public class TargetPositionBaker : Baker<TargetPositionAuthoring>
    {
        public override void Bake(TargetPositionAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new TargetPosition
            {
                targetPosition = authoring.value
            });
        }
    }
}
