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
    /// System base should be use for simple job
    /// </summary>
    public partial class MovingSystemBase : SystemBase
    {
        protected override void OnUpdate()
        {
            //! This does work
            // Entities.ForEach ((ref LocalTransform aspect, in Speed speed, in TargetPosition targetPos) =>
            // {
                // Entities.ForEach ((ref LocalTransform aspect, in Speed speed) =>
                // {
                 // float3 direction = math.normalize(targetPos.targetPosition - aspect.Position);
                 // aspect.Position += new float3(SystemAPI.Time.DeltaTime * speed.speedValue * direction);
                // aspect.Position += new float3(SystemAPI.Time.DeltaTime * speed.speedValue,0,0);
            // }).Run();
                
            //! If we use Schedule. It will run on main thread
            //! If we use ScheduleParallel, it will run on multiple thread

          
            //! This also does work but it will not work with ISystemBase
            // foreach (var(speed, transform, target) in SystemAPI.Query<RefRO<Speed>,RefRW<LocalTransform>, RefRW<TargetPosition>>())
            // {
            //     transform.ValueRW = transform.ValueRO.Translate(GetRandomPosition() * speed.ValueRO.speedValue * SystemAPI.Time.DeltaTime);
            //     
            //     float reachedTargetDistance = .5f;
            //     if (math.distance(transform.ValueRO.Position, target.ValueRW.targetPosition) < reachedTargetDistance)
            //     {
            //         target.ValueRW.targetPosition = GetRandomPosition();
            //     }
            // }
            
            //! This also does work but it will not work with ISystemBase
            foreach (MoveToPositionAspect moveToPositionAspect in SystemAPI.Query<MoveToPositionAspect>())
            {
                // transform.ValueRW = transform.ValueRO.Translate(GetRandomPosition() * speed.ValueRO.speedValue * SystemAPI.Time.DeltaTime);
                
                // float reachedTargetDistance = .5f;
                // if (math.distance(transform.ValueRO.Position, target.ValueRW.targetPosition) < reachedTargetDistance)
                // {
                //     target.ValueRW.targetPosition = GetRandomPosition();
                // }
                moveToPositionAspect.Move(SystemAPI.Time.DeltaTime, new Random(1));
            }
        }

        private float3 GetRandomPosition()
        {
           Random random = new Random(1);

            return new float3(
                random.NextFloat(0f, 15f),
                0,
                random.NextFloat(0f,15f)
            );
        }
    }
}
