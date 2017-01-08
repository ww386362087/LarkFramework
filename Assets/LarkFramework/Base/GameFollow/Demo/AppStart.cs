/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-11-28 10:08:56
 * 修改：evesgf    修改时间：2016-11-28 10:09:01
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：程序启动入口，提供developing状态下的上下文数据
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

namespace LarkFramework.GameFollow.Demo
{

    public class AppStart : MonoBehaviour
    {
        public AppEnums.AppMode mode;
        public bool openDebug;

        // Use this for initialization
        void Start()
        {
            StartCoroutine(AppLaunching());
        }

        IEnumerator AppLaunching()
        {
            //配置加载
            //FPS
            AppConfig.appMode = mode;
            LarkLog.EnableLog = openDebug;

            //日志输出


            if (My_GameInstance.Instance == null)
            {
                yield return My_GameInstance.Create().Init();
            }

            //进入测试逻辑
            switch (mode)
            {
                case AppEnums.AppMode.Developing:
                    {
                        yield return null;
                    }
                    break;
                case AppEnums.AppMode.QA:
                    {
                        yield return null;
                    }
                    break;
                case AppEnums.AppMode.Release:
                    {
                        yield return null;
                    }
                    break;
            }
        }
    }
}
