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
            Entities.ForEach ((ref LocalTransform aspect, in Speed speed) =>
            {
                aspect.Position += new float3(SystemAPI.Time.DeltaTime * speed.speedValue, 0, 0);
            }).Run();
                
            //! If we use Schedule. It will run on main thread
            //! If we use ScheduleParallel, it will run on multiple thread
        }
    }
}
