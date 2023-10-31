using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECSProgramming
{
    public struct RandomComponent : IComponentData
    {
        public Unity.Mathematics.Random randomValue;
    }
}
