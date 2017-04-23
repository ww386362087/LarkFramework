using UnityEngine;
using System.Collections;
using LarkFramework.UI;
using LarkFramework.Base;
using System;
using LarkFramework.Sound;

namespace LarkFramework.UI.Example
{
    public class AccountView : ViewBase,IResourcesListener
    {
        public GameObject rigisterPanel;

        #region Sound 2017-04-23 22:37:49
        private AudioClip clip_BGM;
        private AudioClip clip_Click;
        #endregion

        public AccountView() : base(ViewType.Normal, ViewMode.DoNothing, ViewCollider.None)
        {
            viewPath = "Views/AccountCanvas";
        }

        private void Start()
        {
            //TODO:UI缺少Init方法
            ResourcesMgr.Instance.Load("Sound/bgm", typeof(AudioClip), this);
            ResourcesMgr.Instance.Load("Sound/click", typeof(AudioClip), this);
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

            SoundMgr.Instance.PlayEffectMusic(clip_Click);
        }

        public void OnShowRegister()
        {
            rigisterPanel.SetActive(true);

            SoundMgr.Instance.PlayEffectMusic(clip_Click);
        }

        public void OnExit()
        {
            Application.Quit();

        }

        public void OnCloseRegister()
        {
            rigisterPanel.SetActive(false);

            SoundMgr.Instance.PlayEffectMusic(clip_Click);
        }

        public void OnRegister()
        {
            OnCloseRegister();
            SoundMgr.Instance.PlayEffectMusic(clip_Click);
        }

        private void OnDestroy()
        {
            clip_BGM = null;
            clip_Click = null;
        }

        public void OnLoaded(string assetName, object asset)
        {
            AudioClip clip = asset as AudioClip;
            switch (assetName)
            {
                case "Sound/bgm":
                    clip_BGM = clip;
                    SoundMgr.Instance.PlayBgMusic(clip_BGM);
                    break;
                case "Sound/click":
                    clip_Click = clip;
                    break;

                default:
                    break;
            }
        }
    }

}
