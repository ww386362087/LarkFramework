using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace LarkFramework.Test
{
    public class UIManager : SingletonMono<UIManager> {

        /// <summary>
        /// 记录已经加载进来的UI
        /// </summary>
        public Dictionary<string, BaseUI> _UIDict = new Dictionary<string, BaseUI>();
        /// <summary>
        /// UI导航链
        /// </summary>
        public Stack<string> _UIStack = new Stack<string>();

        //场景中的Canvas
        private Transform _canvas;

        /// <summary>
        /// TODO:构造时清除MainUICanvas下的UI，因为UI都是load进来的
        /// </summary>
        private UIManager()
        {
            //_canvas = GameObject.Find("MainUICanvas").transform;
            //foreach (Transform item in _canvas)
            //{
            //    GameObject.Destroy(item.gameObject);
            //}
        }

        void Start()
        {
            _canvas = GameObject.Find("MainUICanvas").transform;
            foreach (Transform item in _canvas)
            {
                GameObject.Destroy(item.gameObject);
            }
            _canvas.transform.SetParent(transform);
        }

        #region Action API evesgf 2016-8-4 11:18:11

        /// <summary>
        /// 打开页面
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void ShowPage<T>() where T : BaseUI, new()
        {
            Type t = typeof(T);
            string uiName = t.Name.ToString();

            //如果存在于字典中则调用字典
            if (_UIDict != null && _UIDict.ContainsKey(uiName))
            {
                ShowPage(uiName,_UIDict[uiName],null,null,false);
            }
            else
            {
                T instance = new T();
                ShowPage(uiName, instance, null, null, false);
            }
        }

        public void ShowPage(string uiName, BaseUI uiInstance, Action callback, object pageData, bool isAsync)
        {
            if (string.IsNullOrEmpty(uiName) || uiInstance == null)
            {
                Debug.LogError("[UI] show page error with :" + uiName + " maybe null instance.");
                return;
            }

            BaseUI ui = null;
            if (_UIDict.ContainsKey(uiName))
            {
                ui = _UIDict[uiName];
            }
            else
            {
                ui = uiInstance;
            }

            if (isAsync)
            {
                //TODO:Async Load UI 未实现
                //Show(ui);
            }
            else
            {
                Show(uiName, ui, pageData);
            }
        }

        public void Show(string uiName,BaseUI uiInstance,object pageData)
        {
            if (!_UIDict.ContainsKey(uiName))
            {
                var obj = (GameObject)Instantiate(Resources.Load(uiInstance.uiPath));

                if (obj == null)
                {
                    Debug.LogError("[UI] Cant sync load your ui prefab.");
                    //移除
                    _UIDict.Remove(uiName);
                    return;
                }

                _UIDict.Add(uiName, uiInstance);

                AnchorUIGameObject(obj);
            }
        }

        /// <summary>
        /// 锚定UI
        /// </summary>
        /// <param name="ui"></param>
        public void AnchorUIGameObject(GameObject ui)
        {
            Vector3 anchorPos = Vector3.zero;
            Vector2 sizeDel = Vector2.zero;
            Vector3 scale = Vector3.one;
            if (ui.GetComponent<RectTransform>() != null)
            {
                anchorPos = ui.GetComponent<RectTransform>().anchoredPosition;
                sizeDel = ui.GetComponent<RectTransform>().sizeDelta;
                scale = ui.GetComponent<RectTransform>().localScale;
            }

            ui.transform.SetParent(_canvas.transform);

            if (ui.GetComponent<RectTransform>() != null)
            {
                ui.GetComponent<RectTransform>().anchoredPosition = anchorPos;
                ui.GetComponent<RectTransform>().sizeDelta = sizeDel;
                ui.GetComponent<RectTransform>().localScale = scale;
            }

            //TODO:多个Canvas分层时候通过UIType锚定
            //if (type == UIType.Fixed)
            //{
            //    ui.transform.SetParent(TTUIRoot.Instance.fixedRoot);
            //}
            //else if (type == UIType.Normal)
            //{
            //    ui.transform.SetParent(TTUIRoot.Instance.normalRoot);
            //}
            //else if (type == UIType.PopUp)
            //{
            //    ui.transform.SetParent(TTUIRoot.Instance.popupRoot);
            //}
        }

        public void Show(Action callback)
        {
            //TODO:UI SHOW的异步方法尚未实现
        }

        /// <summary>
        /// 打开页面，同时根据传入的参数刷新界面
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageData"></param>
        public void ShowPage<T>(object pageData) where T : BaseUI, new()
        {
            Type t = typeof(T);
            string uiName = t.Name.ToString();

            if (_UIDict != null && _UIDict.ContainsKey(uiName))
            {
                ShowPage(uiName, _UIDict[uiName], null, pageData, false);
            }
            else
            {
                T instance = new T();
                ShowPage(uiName, instance, null, pageData, false);
            }
        }

        #endregion
    }
}
