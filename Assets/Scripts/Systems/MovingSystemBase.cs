using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace ECSProgramming
{
    /// <summary>
    /// System base should be use for simple job or non performance worry
    /// </summary>
    public partial class MovingSystemBase : SystemBase
    {
        protected override void OnCreate()
        {
            int total = EntityManager.EntityCapacity;
            Debug.Log($"Total entities {total}");
        }
        
        protected override void OnUpdate()
        {
            #region To Clean
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
            #endregion

            //! How to use this Entity?
            //! What does it do?
            Entity playerEntityQuery = EntityManager.CreateEntity(typeof(Team));
            
            //! Need to assign the team value. How do I assign this at the start of the game?
            Entities.ForEach((ref Team team) =>
            {
                if (team.teamValue == 0)
                    team.teamValue = 1;
            }).Run();
            
            //! Assign random value
            RefRW<RandomComponent> random = SystemAPI.GetSingletonRW<RandomComponent>();
            
            //! This also does work but it will not work with ISystemBase
            foreach (MoveToPositionAspect moveToPositionAspect in SystemAPI.Query<MoveToPositionAspect>())
            {
                #region To Clean
                // transform.ValueRW = transform.ValueRO.Translate(GetRandomPosition() * speed.ValueRO.speedValue * SystemAPI.Time.DeltaTime);
                
                // float reachedTargetDistance = .5f;
                // if (math.distance(transform.ValueRO.Position, target.ValueRW.targetPosition) < reachedTargetDistance)
                // {
                //     target.ValueRW.targetPosition = GetRandomPosition();
                // }
                #endregion
                
                moveToPositionAspect.Move(SystemAPI.Time.DeltaTime, random);
            }
        }

        #region To Clean
        private float3 GetRandomPosition()
        {
           Random random = new Random(1);

            return new float3(
                random.NextFloat(0f, 15f),
                0,
                random.NextFloat(0f,15f)
            );
        }
        #endregion
    }
}
