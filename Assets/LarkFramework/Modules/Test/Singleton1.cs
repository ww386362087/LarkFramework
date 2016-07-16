using System;
using UnityEngine;

namespace LarkFramework.Test
{
    [RequireComponent(typeof(GameRoot))]
    public class Singleton1<T> : MonoBehaviour where T : Singleton1<T>
    {
        private static T _instance;

        public static T GetInstance()
        {
            return _instance;
        }

        public void SetInstance(T t)
        {
            if (_instance == null)
            {
                _instance = t;
            }
        }

        public virtual void Init()
        {
            return;
        }

        public virtual void Release()
        {
            return;
        }
    }
}