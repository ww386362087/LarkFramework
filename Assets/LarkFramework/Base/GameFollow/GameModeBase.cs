/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-10-2 00:35:58
 * 修改：evesgf    修改时间：2017-1-7 11:20:08
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.3
 * 
 * 描述：剔除单例，转为每个场景一个
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using System;
using LarkFramework.Config;

namespace LarkFramework.GameFlow
{
    public class GameModeBase<T> :ActorBase
        where T : GameInstanceBase<T>
    {
        [HideInInspector]
        public T gameInstance { get; private set; }
        [HideInInspector]
        public GameObject gameInstancePrefab { get; private set; }

        private void Awake()
        {
            Init();
        }

        public virtual void Init()
        {
            CheckGameInstance();

            this.gameInstance = gameInstancePrefab.GetComponent<T>();

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

        /// <summary>
        /// 检查场景中是否存在GameInstance
        /// </summary>
        private void CheckGameInstance()
        {
            if (gameInstancePrefab == null)
            {
                if (FindObjectOfType<T>() != null)
                {
                    T[] instances =FindObjectsOfType<T>() as T[];
                    foreach (var instance in instances)
                    {
                        if (instance.gameObject.scene.name == "DontDestroyOnLoad")
                        {
                            gameInstancePrefab = instance.gameObject;
                        }
                    }
                }
                else
                {
                    //LarkSettings settings = Resources.Load<LarkSettings>(typeof(LarkSettings).Name);
                    //gameInstancePrefab = Instantiate(settings.gameInstancePrefab);
                    //DontDestroyOnLoad(gameInstancePrefab);
                    //gameInstancePrefab.name = typeof(T).Name;
                    gameInstancePrefab=GameInstance.Create().Init().gameObject;
                }
            }
        }
    }
}
