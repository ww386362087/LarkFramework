using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LarkFramework.Config
{
    [Serializable]
    public class LarkSettings : ScriptableObject
    {
        public GameObject gameInstancePrefab;
        public GameObject gameModePrefab;
    }
}
