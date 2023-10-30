using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ECSProgramming
{
    /// <summary>
    /// System base should be use for simple job
    /// </summary>
    public partial class MovingSystemBase : SystemBase
    {
        protected override void OnUpdate()
        {
            foreach (LocalTransform aspect in SystemAPI.Query<LocalTransform>())
            {
                //! This will run on main thread
                //! Foreach loop can do nested cycle
                var localTransform = aspect;
                localTransform.Position += new float3(SystemAPI.Time.DeltaTime, 0, 0);
            }
            
            //! This function is similar
            // Entities.ForEach ((LocalTransform aspect) =>
            // {
            //     aspect.Position += new float3(SystemAPI.Time.DeltaTime, 0, 0);
            // }).Run();
                
            //! If we use Schedule. It will run on main thread
            //! If we use ScheduleParallel, it will run on multiple thread
        }
    }
}
