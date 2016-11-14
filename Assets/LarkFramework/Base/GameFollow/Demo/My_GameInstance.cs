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

        void Start()
        {
            My_GameInstance.Create();
            My_GameMode.Create().Init(this);
        }

        void Update()
        {
            My_GameMode.Instance.OnUpdate();
        }

        void OnDestroy()
        {
            My_GameMode.Instance.OnDestroy();
        }

        void OnApplicationQuit()
        {

        }

        void OnApplicationPause(bool pause)
        {

        }
    }
}