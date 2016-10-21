using UnityEngine;
using System.Collections;

namespace LarkFramework.GameFollow
{
    public class GameModeBase<T> : SingletonMono<T> where T : SingletonMono<T>
    {
        public virtual void Init() { }

        public virtual void OnUpdate() { }
    }
}
