using UnityEngine;
using System.Collections;
using LarkFramework.GameFollow;

namespace LarkFramework.GameFollow.Demo
{
    public class My_GameInstance : GameInstanceBase<My_GameInstance>
    {
        void Awake()
        {

        }

        public My_GameInstance Init()
        {
            My_GameMode.Create().Init(this);
            return this;
        }

        void OnApplicationQuit()
        {

        }

        void OnApplicationPause(bool pause)
        {

        }
    }
}