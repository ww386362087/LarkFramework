/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-11-28 10:08:56
 * 修改：evesgf    修改时间：2016-11-28 10:09:01
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：定制化Log命令
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

namespace LarkFramework
{
    public class LarkLog
    {
        //TODO:在Console面板双击时无法跳转至编译器指定行
        public static void Log(string str)
        {
            Debug.Log(Config.LogTitle() + str);
        }

        public static void LogWarning(string str)
        {
            Debug.LogWarning(Config.LogTitle() + str);
        }

        public static void LogError(string str)
        {
            Debug.LogError(Config.LogTitle() + str);
        }
    }
}
