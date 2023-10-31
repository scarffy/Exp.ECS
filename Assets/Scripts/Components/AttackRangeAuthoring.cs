using Unity.Entities;
using UnityEngine;

namespace ECSProgramming
{
    public class AttackRangeAuthoring : MonoBehaviour
    {
        public float value;
    }

    public class AttackRangeBaker : Baker<AttackRangeAuthoring>
    {
        public override void Bake(AttackRangeAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new AttackRange
            {
                attackRangeValue = authoring.value
            });
        }
    }
}