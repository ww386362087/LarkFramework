using UnityEngine;
using System.Collections;
using LarkFramework.UI;

namespace LarkFramework.UI.Example
{
    public class AccountView : ViewBase
    {
        public GameObject rigisterPanel;

        public AccountView() : base(ViewType.Normal, ViewMode.DoNothing, ViewCollider.None)
        {
            viewPath = "Views/AccountCanvas";
        }

        public override void ShowView()
        {
            base.ShowView();

            OnCloseRegister();

            if (guiAnimItems.Length == 0) return;

            for (var i = 0; i < guiAnimItems.Length; i++)
            {
                guiAnimItems[i].MoveIn();
            }
        }

        public override void Hide()
        {
            base.Hide();

            if (guiAnimItems.Length == 0) return;

            for (var i = 0; i < guiAnimItems.Length; i++)
            {
                guiAnimItems[i].MoveOut();
            }
        }

        public void OnLogin()
        {
            Hide();
            ViewMgr.ShowView<MainView>();            
        }

        public void OnShowRegister()
        {
            rigisterPanel.SetActive(true);
        }

        public void OnExit()
        {
            Application.Quit();
        }

        public void OnCloseRegister()
        {
            rigisterPanel.SetActive(false);
        }

        public void OnRegister()
        {
            OnCloseRegister();
        }
    }

}
