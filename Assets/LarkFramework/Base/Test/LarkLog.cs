/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-11-28 10:08:56
 * 修改：evesgf    修改时间：2016-11-28 10:09:01
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：定制化Log命令,因封装后无法跳转至IDE指定行，故需封装成dll
 ---------------------------------------------------------------*/

using UnityEngine;

namespace LarkFramework
{
    public class LarkLog
    {
        static public bool EnableLog = false;

        public static void Log(string msg)
        {
            if(EnableLog)
                Debug.Log(LarkConfig.LogTitle() + msg);
        }
        public static void Log(string msg,Object context)
        {
            if (EnableLog)
                Debug.Log(LarkConfig.LogTitle() + msg, context);
        }

        public static void LogWarning(string msg)
        {
            if (EnableLog)
                Debug.Log(LarkConfig.LogTitle() + msg);
        }
        public static void LogWarning(string msg, Object context)
        {
            if (EnableLog)
                Debug.Log(LarkConfig.LogTitle() + msg, context);
        }

        public static void LogError(string msg)
        {
            if (EnableLog)
                Debug.Log(LarkConfig.LogTitle() + msg);
        }
        public static void LogError(string msg, Object context)
        {
            if (EnableLog)
                Debug.Log(LarkConfig.LogTitle() + msg, context);
        }
    }
}
