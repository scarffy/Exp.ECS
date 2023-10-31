using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECSProgramming
{
    public class AttackAuthoring : MonoBehaviour
    {
        public int value;
    }

    public class AttackBaker : Baker<AttackAuthoring>
    {
        public override void Bake(AttackAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Attack
            {
                attackValue = authoring.value
            });
        }
    }
}
