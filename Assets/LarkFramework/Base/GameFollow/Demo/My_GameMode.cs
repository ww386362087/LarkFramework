using UnityEngine;
using System.Collections;
using LarkFramework.GameFollow;

namespace LarkFramework.GameFollow.Demo
{
    public class My_GameMode : GameModeBase<My_GameMode,My_GameInstance>
    {
        public override void Init(My_GameInstance gameInstance, GameObject obj)
        {
            base.Init(gameInstance, obj);

            this.gameInstance.onUpdate += OnUpdate;

            //Init各类管理器
            My_ScenesMgr.Create().Init();

            LarkLog.Log(this.name + " Init Finished");
        }
    }

}