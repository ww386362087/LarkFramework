/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-10-2 00:35:58
 * 修改：evesgf    修改时间：2016-10-2 00:36:01
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：实例化组件
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

namespace LarkFramework
{
    public class GameMode : SingletonMono<GameMode>
    {
        public GameInstance gameInstance { get; private set; }
        public GameObject gameInstanceObj { get; private set; }

        public void Init(GameInstance gameInstance)
        {
            //Init各类管理器
            this.gameInstance = gameInstance;
            this.gameInstanceObj = gameInstance.gameObject;

            print("this is init:"+this.gameInstance);
        }

        public void OnUpdate()
        {
            //Update各类管理器
            print("this is Update:" + this.gameInstance);
        }

        public void Destroy()
        {
            //Destory各类管理器
            print("this is Destroy:" + this.gameInstance);
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
