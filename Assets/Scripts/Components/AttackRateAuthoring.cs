using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECSProgramming
{
    public class AttackRateAuthoring : MonoBehaviour
    {
        public float value;
    }

    public class AttackRateBaker : Baker<AttackRateAuthoring>
    {
        public override void Bake(AttackRateAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new AttackRate
            {
                attackRateValue = authoring.value
            });
        }
    }
}
