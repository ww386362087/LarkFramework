/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-11 22:57:56
 * 修改：evesgf    修改时间：2016-6-11 22:58:00
 *
 * 版本：V0.0.1
 * 
 * 描述：
 * 1、实例化游戏初始状态，创建各类manager
 ---------------------------------------------------------------*/

using UnityEngine;

namespace LarkFramework
{
    public class GameInstance : MonoBehaviour
    {
        /// <summary>
        /// 合适创建配置
        /// </summary>
        public CreateType createType = CreateType.isStart;

        private bool isFirstUpdate = true;

        /// <summary>
        /// 创建各类实例
        /// </summary>
        private void CreateInstance()
        {
            if(SingletonHelper<GlobalManager>.Create()!=null)
                Debug.Log("Instance: GlobalManager");
            if (SingletonHelper<ScenesManager>.Create() != null)
                Debug.Log("Instance: ScenesManager");
            if (SingletonHelper<ContextManager>.Create() != null)
                Debug.Log("Instance: ContextManager");
            if (SingletonHelper<UIManager>.Create() != null)
                Debug.Log("Instance: UIManager");
        }

        void Awake()
        {
            if (createType == CreateType.isAwake)
            {
                CreateInstance();
            }
        }

        void OnEnable()
        {
            if (createType == CreateType.isOnEnable)
            {
                CreateInstance();
            }
        }

        void Start()
        {
            if (createType == CreateType.isStart)
            {
                CreateInstance();
            }
        }

        void Update()
        {
            if (createType == CreateType.isUpdateFirst)
            {
                if (isFirstUpdate)
                {
                    CreateInstance();
                    isFirstUpdate = false;
                }
            }
        }

        public enum CreateType
        {
            isAwake=0,
            isOnEnable=1,
            isStart=2,
            isUpdateFirst=3
        }
    }
}
