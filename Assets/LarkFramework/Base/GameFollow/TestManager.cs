using UnityEngine;
using System.Collections;

namespace LarkFramework
{
    public class TestManager : SingletonMono<TestManager>
    {

        // Use this for initialization
        void Start()
        {
            print("this is TestManager Start");
        }

        // Update is called once per frame
        void Update()
        {
            print("this is TestManager Update");
        }
    }
}
