using UnityEngine;
using System.Collections;

namespace LarkFramework.Test
{
    public class Test_StartUI : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            UIPage.ShowPage<Test_HelloWorld>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
