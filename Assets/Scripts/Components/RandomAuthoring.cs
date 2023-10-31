using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECSProgramming
{
    public class RandomAuthoring : MonoBehaviour
    {
        
    }

    public class RandomBaker : Baker<RandomAuthoring>
    {
        public override void Bake(RandomAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new RandomComponent()
            {
                randomValue = new Unity.Mathematics.Random(1)
            });
        }
    }
}
