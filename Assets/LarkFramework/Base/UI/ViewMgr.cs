/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-11-30 14:16:37
 * 修改：evesgf    修改时间：2016-11-30 14:16:41
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：UI状态管理类
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using System;
using LarkFramework.ResourcesMgr;
using UnityEngine.EventSystems;

namespace LarkFramework.UI
{
    public class ViewMgr : MonoBehaviour,IResourcesListener
    {
        /// <summary>
        /// 显示UI
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void ShowView<T>() where T: ViewBase, new()
        {
            ShowView<T>(null, null, false);
        }

        /// <summary>
        /// 显示UI并传入数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageData"></param>
        public static void ShowView<T>(object pageData) where T : ViewBase, new()
        {
            ShowView<T>(null, pageData, false);
        }

        /// <summary>
        /// TODO:View的上下文待实现
        /// TODO:View异步加载待实现
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="callback"></param>
        /// <param name="pageData"></param>
        /// <param name="isAsync"></param>
        public static void ShowView<T>(Action callback,object pageData,bool isAsync) where T : ViewBase, new()
        {
            T instance = new T();
            Type type = typeof(T);

            LoadView(instance.viewPath,type);
        }

        /// <summary>
        /// 根据传入路径从Resources中加载view
        /// </summary>
        /// <param name="viewPath"></param>
        /// <param name="typeName"></param>
        public static void LoadView(string viewPath,Type type)
        {
            if (string.IsNullOrEmpty(viewPath))
            {
                LarkLog.LogError("View Path is Null:" + "<color=silver><" + type.Name + "></color>");
                return;
            }

            var uiMgr = GameObject.FindObjectOfType<EventSystem>().transform;
            var load = Resources.Load(viewPath) as GameObject;

            if (load == null)
            {
                LarkLog.LogError("Cant Load view prefab:" + "<color=silver><" + type.Name + "></color>" + viewPath);
                return;
            }

            GameObject page = GameObject.Instantiate(load) as GameObject;

            if (page == null)
            {
                LarkLog.LogError("Cant Instantiate view prefab:" + "<color=silver><" + type.Name + "></color>" + viewPath);
                return;
            }

            //UGUI特定bug，UI加载后为场景树最外层坐标，再指定父对象
            //则自动变更，故需先存储坐标再指定父对象再赋值坐标
            Vector3 anchorPos = Vector3.zero;
            Vector2 sizeDel = Vector2.zero;
            Vector3 scale = Vector3.one;

            anchorPos = page.GetComponent<RectTransform>().anchoredPosition;
            sizeDel = page.GetComponent<RectTransform>().sizeDelta;
            scale = page.GetComponent<RectTransform>().localScale;

            page.transform.parent = uiMgr.transform;

            page.GetComponent<RectTransform>().anchoredPosition = anchorPos;
            page.GetComponent<RectTransform>().sizeDelta = sizeDel;
            page.GetComponent<RectTransform>().localScale = scale;

            var view = page.GetComponent<ViewBase>();
            view.viewGameObject = page;
            view.ShowView();
        }

        public void OnLoaded(string assetName, object asset)
        {
            //TODO:对接ResourcesMgr
        }
    }
}
