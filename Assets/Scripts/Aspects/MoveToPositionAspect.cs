using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace ECSProgramming
{
    /// <summary>
    /// For some reason the aspect move doesn't work
    /// </summary>
    public readonly partial struct MoveToPositionAspect : IAspect
    {
        //! One of the main purpose of Aspect is to group together logics
        private readonly Entity entity;
        
        //! Can be regular component or other aspect
        //! We want to write new value to local transform
        private readonly RefRW<LocalTransform> transformAspect;
        private readonly RefRO<Speed> speed;
        private readonly RefRW<TargetPosition> targetPosition;

        public void Move(float deltaTime, Random random)
        {
            float3 direction = math.normalize(targetPosition.ValueRW.targetPosition - transformAspect.ValueRO.Position);
            transformAspect.ValueRW.Position += direction * speed.ValueRO.speedValue * deltaTime;

            float reachedTargetPosition = .5f;
            if (math.distance(transformAspect.ValueRO.Position, targetPosition.ValueRW.targetPosition) <
                reachedTargetPosition)
            {
                targetPosition.ValueRW.targetPosition = GetRandomPosition(random);
            }
        }

        private float3 GetRandomPosition(Random random)
        {
            return new float3(
                random.NextFloat(0f,15f), 
                0,
                random.NextFloat(0f,15f)
            );
        }
    }
}
