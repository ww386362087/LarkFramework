using UnityEngine;
using System.Collections;

namespace LarkFramework.GameFlow
{
    public class GameInstance : GameInstanceBase<GameInstance>
    {
        public GameInstance Init()
        {
            //初始化GameMode
            //My_GameMode.Create().Init(this, gameObject);

            Debug.Log(this.name + " Init Finished");
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
