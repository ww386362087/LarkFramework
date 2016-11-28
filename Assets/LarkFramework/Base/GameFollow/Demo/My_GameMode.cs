using UnityEngine;
using System.Collections;
using LarkFramework.GameFollow;

namespace LarkFramework.GameFollow.Demo
{
    public class My_GameMode : GameModeBase<My_GameMode>
    {
        public My_GameInstance gameInstance { get; private set; }
        public GameObject gameInstanceObj { get; private set; }

        public virtual void Init(My_GameInstance gameInstance)
        {
            //Init各类管理器
            this.gameInstance = gameInstance;
            this.gameInstanceObj = gameInstance.gameObject;

            print("----this is init:" + this.gameInstance.GetType().Name);

            My_ScenesMgr.Create().Init();
        }

        public Coroutine StartCoroutine(IEnumerator routine)
        {
            return this.gameInstance.StartCoroutine(routine);
        }

        public void Coroutine(IEnumerator routine)
        {
            this.gameInstance.StopCoroutine(routine);
        }
    }

}