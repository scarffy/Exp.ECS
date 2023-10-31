using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECSProgramming
{
    public struct Health : IComponentData
    {
        public int healthValue;
    }
}
