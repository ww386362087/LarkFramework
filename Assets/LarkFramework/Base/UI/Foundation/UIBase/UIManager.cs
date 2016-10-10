/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-8-5 08:58:24
 * 修改：evesgf    修改时间：2016-8-5 08:58:27
 *
 * 版本：V0.0.2
 * 
 * 描述：UI管理类
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LarkFramework
{
    public class UIManager:Singleton<UIManager>
    {
        public Dictionary<UIType, GameObject> _UIDict = new Dictionary<UIType, GameObject>();

        private Transform _canvas;

        private UIManager()
        {
            _canvas = GameObject.Find("MainUICanvas").transform;
            foreach (Transform item in _canvas)
            {
                GameObject.Destroy(item.gameObject);
            }
        }

        public GameObject GetSingleUI(UIType uiType)
        {
            if (_UIDict.ContainsKey(uiType) == false || _UIDict[uiType] == null)
            {
                var temp = Resources.Load<GameObject>(uiType.Path) as GameObject;
                if (temp == null)
                {
                    Debug.LogError("[UI] Load ui is null!Please Check uiType.Path!");
                    return null;
                }

                GameObject obj = GameObject.Instantiate(temp);
                obj.transform.SetParent(_canvas, false);
                obj.name = uiType.Name;
                _UIDict.AddOrReplace(uiType, obj);
                return obj;
            }

            return _UIDict[uiType];
        }
    }
}
