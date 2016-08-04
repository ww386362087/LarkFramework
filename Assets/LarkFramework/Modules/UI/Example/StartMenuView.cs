using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace LarkFramework.Test
{
    public class StartMenuView : BaseUI
    {
        public StartMenuView() : base(UIType.Fixed, UIMode.DoNothing, UICollider.WithBg)
        {
            uiPath = "Views/StartMenuView";
        }

        [SerializeField]
        private Button btn_Main;
        [SerializeField]
        private Button btn_Close;

        public void OpenMain()
        {

        }

        public void CloseSelf()
        {

        }
    }
}
