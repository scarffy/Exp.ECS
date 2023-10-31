using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECSProgramming
{
    public class HealthAuthoring : MonoBehaviour
    {
        public int value;
    }

    public class HealthBaker : Baker<HealthAuthoring>
    {
        public override void Bake(HealthAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Health
            {
                healthValue = authoring.value
            });
        }
    }
}
