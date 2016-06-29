/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-30 02:16:32
 * 修改：evesgf    修改时间：2016-6-30 02:16:35
 *
 * 版本：V0.0.1
 * 
 * 描述：
 * 1、MonoBehaviour的单例
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

namespace LarkFramework
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        protected static T mInstance = null;

        public static T Instance()
        {
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<T>();

                if (FindObjectsOfType<T>().Length > 1)
                {
                    QPrint.FrameworkError("More than 1!");

                    return mInstance;
                }

                if (mInstance == null)
                {
                    string instanceName = typeof(T).Name;

                    QPrint.FrameworkLog("Instance Name: " + instanceName);

                    GameObject instanceGO = GameObject.Find(instanceName);

                    if (instanceGO == null)
                        instanceGO = new GameObject(instanceName);
                    mInstance = instanceGO.AddComponent<T>();

                    DontDestroyOnLoad(instanceGO);

                    QPrint.FrameworkLog("Add New Singleton " + mInstance.name + " in Game!");

                }
                else
                {
                    QPrint.FrameworkLog("Already exist: " + mInstance.name);
                }
            }

            return mInstance;
        }


        protected virtual void OnDestroy()
        {
            mInstance = null;
        }
    }
}
