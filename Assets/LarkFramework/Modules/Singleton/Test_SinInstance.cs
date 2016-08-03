using UnityEngine;
using System.Collections;

namespace LarkFramework.Test
{
    public class Test_SinInstance : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (Singleton<ShowSin1>.Create()!=null)
                    Debug.Log("Create ShowSin1 Access");

                if (SingletonReflex<ShowSin2>.Create() != null)
                    Debug.Log("Create ShowSin2 Access");

                if(SingletonMono<ShowSin3>.Create()!=null)
                    Debug.Log("Create ShowSin3 Access");
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Singleton<ShowSin1>.Instance.DoSomething();
                SingletonReflex<ShowSin2>.Instance.DoSomething();
                SingletonMono<ShowSin3>.Instance.DoSomething();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Singleton<ShowSin1>.Destroy();
                SingletonReflex<ShowSin2>.Destroy();
                SingletonMono<ShowSin3>.Destroy();
            }
        }
    }

    public class ShowSin1:Singleton<ShowSin1>
    {
        public void DoSomething()
        {
            Debug.Log("Singleton ShowSin1 DoSomething");
        }
    }

    public class ShowSin2 : SingletonReflex<ShowSin2>
    {
        /// <summary>
        /// 注意这里是私有滴~~~
        /// </summary>
        private ShowSin2()
        {

        }

        public void DoSomething()
        {
            Debug.Log("SingletonReflex ShowSin2 DoSomething");
        }
    }

    public class ShowSin3 : SingletonMono<ShowSin3>
    {
        public void DoSomething()
        {
            Debug.Log("SingletonMono ShowSin3 DoSomething");
        }
    }
}
