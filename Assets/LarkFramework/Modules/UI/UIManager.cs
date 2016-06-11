/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-11 19:34:01
 * 修改：evesgf    修改时间：2016-6-11 19:34:01
 *
 * 版本：
 * 
 * 描述：
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LarkFramework
{
    public class UIManager
    {
        public Dictionary<UIType, GameObject> _UIDict = new Dictionary<UIType, GameObject>();

        private Transform _canvas;

        private UIManager()
        {
            _canvas = GameObject.Find("Canvas").transform;
            foreach (Transform item in _canvas)
            {
                GameObject.Destroy(item.gameObject);
            }
        }

        public GameObject GetSingleUI(UIType uiType)
        {
            if (_UIDict.ContainsKey(uiType) == false || _UIDict[uiType] == null)
            {
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>(uiType.Path)) as GameObject;
                go.transform.SetParent(_canvas, false);
                go.name = uiType.Name;
                _UIDict.AddOrReplace(uiType, go);
                return go;
            }
            return _UIDict[uiType];
        }

        public void DestroySingleUI(UIType uiType)
        {
            if (!_UIDict.ContainsKey(uiType))
            {
                return;
            }

            if (_UIDict[uiType] == null)
            {
                _UIDict.Remove(uiType);
                return;
            }

            GameObject.Destroy(_UIDict[uiType]);
            _UIDict.Remove(uiType);
        }
    }
}
