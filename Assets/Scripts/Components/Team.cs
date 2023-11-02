using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECSProgramming
{
    public struct Team : IComponentData
    {
        public int teamValue;
    }
}
