/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-11-30 14:08:45
 * 修改：evesgf    修改时间：2016-11-30 14:08:48
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：UI基类
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

namespace LarkFramework.UI
{
    public abstract class ViewBase : MonoBehaviour
    {
        /// <summary>
        /// view的名字
        /// </summary>
        public string viewName;

        /// <summary>
        /// view在Resources中的存储路径
        /// </summary>
        public string viewPath;

        /// <summary>
        /// view的类型
        /// </summary>
        public ViewType viewType=ViewType.Normal;

        /// <summary>
        /// view的打开模式
        /// </summary>
        public ViewMode viewMode = ViewMode.DoNothing;

        /// <summary>
        /// view的碰撞背景类型
        /// </summary>
        public ViewCollider viewCollider = ViewCollider.Normal;

        /// <summary>
        /// View打开状态标识
        /// </summary>
        public bool isActived;

        /// <summary>
        /// View自身GameObject
        /// </summary>
        public GameObject viewGameObject;
        /// <summary>
        /// View自身transform
        /// </summary>
        public Transform viewTransform;

        /// <summary>
        /// GUIAnim相关动效组件
        /// </summary>
        public GUIAnim[] guiAnimItems;

        /// <summary>
        /// View数据
        /// </summary>
        private object m_data;
        public object data { get { return m_data; } }

        /// <summary>
        /// ViewBase的构造函数
        /// </summary>
        /// <param name="normal"></param>
        /// <param name="doNothing"></param>
        /// <param name="none"></param>
        public ViewBase(ViewType type, ViewMode mode, ViewCollider col)
        {
            viewType = type;
            viewMode = mode;
            viewCollider = col;
            viewName = this.GetType().ToString();
        }

        /// <summary>
        /// 打开view
        /// </summary>
        public virtual void ShowView()
        {
            viewGameObject.SetActive(true);
            isActived = true;
            GUIAnimatorExtensions.Show(guiAnimItems);
        }

        /// <summary>
        /// 刷新view
        /// </summary>
        public virtual void Refresh() { }

        /// <summary>
        /// 关闭view
        /// </summary>
        public virtual void Hide()
        {
            viewGameObject.SetActive(false);
            isActived = false;
            m_data = null;
            GUIAnimatorExtensions.Hide(guiAnimItems);
        }
    }

    #region 定义UI的状态

    public enum ViewType
    {
        Normal,
        Fixed,
        PopUp,
        None,            //独立的窗口
    }

    public enum ViewMode
    {
        DoNothing,          
        HideOther,          //关闭其他界面
        NeedBack,           //关闭当前界面，不关闭其他界面
        NoNeedBack,         //关闭其他界面同时清空导航链
    }

    public enum ViewCollider
    {
        None,           //不包含碰撞背景
        Normal,         //碰撞透明背景
        WithBg,         //碰撞非透明背景
    }

    #endregion
}
