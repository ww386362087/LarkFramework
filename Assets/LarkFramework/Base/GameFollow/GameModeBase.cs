/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-10-2 00:35:58
 * 修改：evesgf    修改时间：2017-1-7 11:20:08
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.2
 * 
 * 描述：实例化组件
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using System;

namespace LarkFramework.GameFollow
{
    public class GameModeBase<T1,T2> : SingletonMono<T1>
        where T1 : SingletonMono<T1>
        where T2 : GameInstanceBase<T2>
    {
        [HideInInspector]
        public T2 gameInstance { get; private set; }
        [HideInInspector]
        public GameObject gameInstanceObj { get; private set; }

        public virtual void Init(T2 gameInstance,GameObject obj)
        {
            this.gameInstance = gameInstance;
            this.gameInstanceObj = obj;

            this.gameInstance.onUpdate += OnUpdate;
        }

        public virtual void OnUpdate() { }

        public virtual void OnFixedUpdate() { }

        public virtual void OnLatedUpdate() { }

        public virtual void OnGUI() { }

        public virtual void OnDestroy() { }

        public virtual void OnApplicationQuit() { }

        #region 协程管理 杨定鹏 2017-1-7 11:19:45
        /// <summary>
        /// 启动单个协程
        /// </summary>
        /// <param name="routine"></param>
        /// <returns></returns>
        public Coroutine StartCoroutineTask(IEnumerator routine, Action<object> callback=null)
        {
            var temp= this.gameInstance.StartCoroutine(routine);

            if (callback != null)
            {
                callback(routine.Current);
            }

            return temp;
        }

        /// <summary>
        /// 停止单个协程
        /// </summary>
        /// <param name="routine"></param>
        public void StopCoroutineTask(IEnumerator routine)
        {
            this.gameInstance.StopCoroutine(routine);
        }

        /// <summary>
        /// 停止所有的协程
        /// </summary>
        public void StopAllCoroutineTask()
        {
            this.gameInstance.StopAllCoroutines();
        }

        #endregion
    }
}
