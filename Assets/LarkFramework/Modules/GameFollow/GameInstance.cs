/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-11 22:57:56
 * 修改：evesgf    修改时间：2016-6-30 02:14:38
 *
 * 版本：V0.1.1
 * 
 * 描述：
 * 1、全局唯一继承于MonoBehaviour的单例类，保证其他公共模块都以
 *  App的生命周期为准。
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

namespace LarkFramework
{
    public class GameInstance : MonoSingleton<GameInstance>
    {
        void Awake()
        {
            //确保不被销毁
            DontDestroyOnLoad(gameObject);

            mInstance = this;

            // 设置帧率为默认60帧
            Application.targetFrameRate = AppConfig.FPS;
        }

        void Start()
        {
            //CoroutineMgr.Instance().StartCoroutine(ApplicationDidFinishLaunching());
        }

        /// <summary>
        /// 进入游戏
        /// </summary>
        IEnumerator ApplicationDidFinishLaunching()
        {
            yield return null;
        }

        #region 全局生命周期回调
        public delegate void LifeCircleCallback();

        public LifeCircleCallback onUpdate = null;
        public LifeCircleCallback onFixedUpdate = null;
        public LifeCircleCallback onLatedUpdate = null;
        public LifeCircleCallback onGUI = null;
        public LifeCircleCallback onDestroy = null;
        public LifeCircleCallback onApplicationQuit = null;

        void Update()
        {
            if (this.onUpdate != null)
                this.onUpdate();
        }

        void FixedUpdate()
        {
            if (this.onFixedUpdate != null)
                this.onFixedUpdate();

        }

        void LatedUpdate()
        {
            if (this.onLatedUpdate != null)
                this.onLatedUpdate();
        }

        void OnGUI()
        {
            if (this.onGUI != null)
                this.onGUI();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (this.onDestroy != null)
                this.onDestroy();
        }

        void OnApplicationQuit()
        {
            if (this.onApplicationQuit != null)
                this.onApplicationQuit();
        }
        #endregion

        /// <summary>
        /// 创建各类实例
        /// </summary>
        private void CreateInstance()
        {
            if (SingletonHelper<GlobalManager>.Create() != null)
                Debug.Log("Instance: GlobalManager");
            if (SingletonHelper<ScenesManager>.Create() != null)
                Debug.Log("Instance: ScenesManager");
            if (SingletonHelper<ContextManager>.Create() != null)
                Debug.Log("Instance: ContextManager");
            if (SingletonHelper<UIManager>.Create() != null)
                Debug.Log("Instance: UIManager");
        }
    }
}
