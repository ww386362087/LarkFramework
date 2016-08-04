/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-8-4 09:48:37
 * 修改：evesgf    修改时间：2016-8-4 09:48:41
 *
 * 版本：V0.0.1
 * 
 * 描述：UI基类
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using System;

namespace LarkFramework
{
    public abstract class BaseUI
    {
        #region UIModel evesgf 2016-8-4 10:05:26
        /// <summary>
        /// UI打开类型
        /// </summary>
        public enum UIType
        {
            Normal,     //基础
            Fixed,      //固定窗口
            PopUp,      //弹窗
            None,       //独立的窗口
        }

        /// <summary>
        /// UI关闭类型
        /// </summary>
        public enum UIMode
        {
            DoNothing,
            HideOther,     // 关闭其他界面
            NeedBack,      // 点击返回按钮关闭当前,不关闭其他界面(需要调整好层级关系)
            NoNeedBack,    // 关闭TopBar,关闭其他界面,不加入backSequence队列
        }

        /// <summary>
        /// UI碰撞背景模式
        /// </summary>
        public enum UICollider
        {
            None,      // 显示该界面不包含碰撞背景
            Normal,    // 碰撞透明背景
            WithBg,    // 碰撞非透明背景
        }
        #endregion

        #region DefaultAttribute evesgf 2016-8-4 11:18:40

        public string name = string.Empty;

        //this page's id
        public int id = -1;

        //this page's type
        public UIType type = UIType.Normal;

        //how to show this page.
        public UIMode mode = UIMode.DoNothing;

        //the background collider mode
        public UICollider collider = UICollider.None;

        //path to load ui
        public string uiPath = string.Empty;

        //this ui's gameobject
        public GameObject gameObject;
        public Transform transform;

        //record this ui load mode.async or sync.
        private bool isAsyncUI = false;

        //this page active flag
        protected bool isActived = false;

        //refresh page 's data.
        private object m_data = null;
        public object data
        {
            get { return m_data; }
            set { m_data = value; }
        }

        /// <summary>
        /// 封闭默认构造函数
        /// </summary>
        private BaseUI() { }

        /// <summary>
        /// 必须指定参数才能构造
        /// </summary>
        /// <param name="type"></param>
        /// <param name="mode"></param>
        /// <param name="col"></param>
        public BaseUI(UIType type, UIMode mode, UICollider col)
        {
            this.type = type;
            this.mode = mode;
            this.collider = col;
            this.name = this.GetType().Name.ToString();
        }

        #endregion

        public virtual void OnEnter()
        {

        }

        public virtual void OnExit()
        {

        }

        public virtual void OnPause()
        {

        }

        public virtual void OnResume()
        {

        }

        //public void DestroySelf()
        //{
        //    Destroy(gameObject);
        //}
    }

}