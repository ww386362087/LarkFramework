/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：$time$
 * 修改：evesgf    修改时间：$time$
 *
 * 版本：
 * 
 * 描述：
 ---------------------------------------------------------------*/

using System;

namespace LarkFramework
{
    public static class SingletonHelper<T> where T : class
    {
        /*	Instance	*/
        private static T _instance;

        /* Static constructor	*/
        static SingletonHelper()
        {
            return;
        }

        public static T Create()
        {
            _instance = (T)Activator.CreateInstance(typeof(T), true);

            return _instance;
        }

        /* Serve the single instance to callers	*/
        public static T Instance
        {
            get
            {
                return _instance;
            }
        }

        /*	Destroy	*/
        public static void Destroy()
        {

            _instance = null;

            return;
        }
    }
}
