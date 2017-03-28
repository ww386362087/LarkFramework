using UnityEngine;
using System.Collections;
using LarkFramework.GameFlow;

namespace LarkFramework.GameFlow
{
    public class GameMode : GameModeBase<GameInstance>
    {
        public override void Init()
        {
            base.Init();

            //添加Tick管理
            this.gameInstance.onUpdate += OnUpdate;

            //Init各类管理器
            //My_ScenesMgr.Create().Init();

            Debug.Log(this.name + " Init Finished");
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            //添加Tick管理
            this.gameInstance.onUpdate -= OnUpdate;

            Debug.Log(this.name + " OnDestroy");
        }
    }
}