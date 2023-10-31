using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECSProgramming
{
    public readonly partial struct MoveToPositionAspect : IAspect
    {
        private readonly RefRO<Speed> speed;
        private readonly RefRW<TargetPosition> targetPosition;
    }
}
