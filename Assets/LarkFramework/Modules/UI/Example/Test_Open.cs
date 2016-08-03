using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace LarkFramework.Test
{
    public class Test_Open : UIPage
    {
        public Test_Open() : base(UIType.Fixed, UIMode.NeedBack, UICollider.None)
        {
            uiPath = "UIPrefab/Test_Open";
        }

        public override void Awake(GameObject go)
        {
            this.gameObject.transform.Find("btn_back").GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log("Open");
                UIPage.ClosePage();
            });
        }
    }
}
