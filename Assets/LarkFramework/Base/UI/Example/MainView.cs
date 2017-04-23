using UnityEngine;
using System.Collections;

namespace LarkFramework.UI.Example
{

    public class MainView : ViewBase
    {
        public MainView() : base(ViewType.Normal, ViewMode.DoNothing, ViewCollider.None)
        {
            viewPath = "Views/MainCanvas";
        }

        public void Start()
        {
            ShowView();
        }

        public override void ShowView()
        {
            base.ShowView();

            if (guiAnimItems.Length == 0) return;

            for (int i = 0; i < guiAnimItems.Length; i++)
            {
                guiAnimItems[i].MoveIn();
            }
        }
    }

}