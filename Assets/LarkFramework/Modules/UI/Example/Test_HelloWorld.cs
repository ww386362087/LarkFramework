using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace LarkFramework.Test
{
    public class Test_HelloWorld : UIPage
    {
        public Test_HelloWorld() : base(UIType.Fixed, UIMode.NeedBack, UICollider.None)
        {
            uiPath = "UIPrefab/Test_HelloWorld";
        }

        public override void Awake(GameObject go)
        {
            this.gameObject.transform.Find("btn_back").GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log("Hello World");
                UIPage.ClosePage();
            });

            this.gameObject.transform.Find("btn_Open").GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log("Open");
                ShowPage<Test_Open>();
            });
        }
    }
}
