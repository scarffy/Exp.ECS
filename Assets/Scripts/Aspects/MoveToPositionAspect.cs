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
        private readonly RefRW<Health> health;
        private readonly RefRO<AttackRange> attackRange;

        public void Move(float deltaTime, RefRW<RandomComponent> randomComponent)
        {
            if (health.ValueRW.healthValue > 1)
            {
                float3 direction =
                    math.normalize(targetPosition.ValueRW.targetPosition - transformAspect.ValueRO.Position);
                transformAspect.ValueRW.Position += direction * speed.ValueRO.speedValue * deltaTime;

                if (math.distance(transformAspect.ValueRO.Position, targetPosition.ValueRW.targetPosition) <
                    attackRange.ValueRO.attackRangeValue)
                {
                    // targetPosition.ValueRW.targetPosition = GetRandomPosition(randomComponent);

                    //! Subtract Health each time unit reach the target position
                    SubtractHealth(1, randomComponent);
                }
            }
        }

        private void SubtractHealth(int value)
        {
            health.ValueRW.healthValue -= value;
        }
        
        private void SubtractHealth(int value, RefRW<RandomComponent> randomComponent)
        {
            health.ValueRW.healthValue -= value;
            targetPosition.ValueRW.targetPosition = GetRandomPosition(randomComponent);
        }
        private float3 GetRandomPosition(RefRW<RandomComponent> randomComponent)
        {
            return new float3(
                randomComponent.ValueRW.randomValue.NextFloat(0f,15f), 
                0,
                randomComponent.ValueRW.randomValue.NextFloat(0f,15f)
            );
        }
    }
}
