using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ECSProgramming
{
    public class GetPlayer : MonoBehaviour
    {
        public Entity targetEntity;

        private void LateUpdate()
        {
            if (Input.GetKeyUp(KeyCode.Space))
                targetEntity = GetRandomEntity();
            if (targetEntity != Entity.Null)
            {
                Vector3 followPosition = World.DefaultGameObjectInjectionWorld.EntityManager
                    .GetComponentData<LocalTransform>(targetEntity)
                    .Position;

                transform.position = followPosition;
            }
        }

        private Entity GetRandomEntity()
        {
            //! Query Entity in the world. Since we know we only use one world, we can get the default world
            EntityQuery playerTeamEntityQuery = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(Team));
            //! Put Entity in Array
            NativeArray<Entity> entityNativeArray = playerTeamEntityQuery.ToEntityArray(Unity.Collections.Allocator.Temp);
            if(entityNativeArray.Length > 0)
            {
                return entityNativeArray[Random.Range(0, entityNativeArray.Length)];
            }
            else
            {
                return Entity.Null;
            }
        }
    }
}