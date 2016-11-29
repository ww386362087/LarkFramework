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
using LarkFramework;

public class AppStart : MonoBehaviour {

    public AppEnums.AppMode mode;
    public bool openDebug;

    // Use this for initialization
    void Start () {
        StartCoroutine(AppLaunching());
	}

    IEnumerator AppLaunching()
    {
        AppConfig.appMode = mode;
        LarkLog.EnableLog = openDebug;

        //配置加载
        Application.targetFrameRate = 60;


        //日志输出


        if (My_GameInstance.Instance == null)
        {
            yield return My_GameInstance.Create().Init();
        }

        //进入测试逻辑
        switch (AppConfig.appMode)
        {
            case AppEnums.AppMode.Developing:
                {
                    LarkLog.EnableLog = true;

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
                    LarkLog.EnableLog = false;

                    yield return null;
                }
                break;
        }
    }
}
