using Unity.Entities;
using UnityEngine;

namespace ECSProgramming
{
    public class TeamAuthoring : MonoBehaviour
    {
        public int value;
    }

    public class TeamBaker : Baker<TeamAuthoring>
    {
        public override void Bake(TeamAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Team
            {
                teamValue = authoring.value
            });
        }
    }
}