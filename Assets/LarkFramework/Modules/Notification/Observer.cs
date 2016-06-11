/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-11 16:28:56
 * 修改：evesgf    修改时间：2016-6-11 16:29:00
 *
 * 版本：
 * 
 * 描述：
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections.Generic;
using System;

namespace LarkFramework
{

    public class Observer : MonoBehaviour
    {
        private INotificationCenter center;
        private Dictionary<string, EventHandler> handlers;

        void Awake()
        {
            handlers = new Dictionary<string, EventHandler>();
            center = NotificationCenter.GetInstance();
        }

        void OnDestroy()
        {
            foreach (KeyValuePair<string, EventHandler> kvp in handlers)
            {
                center.RemoveEventHandler(kvp.Key, kvp.Value);
            }
        }

        public void AddEventHandler(string name, EventHandler handler)
        {
            center.AddEventHandler(name, handler);
            handlers.Add(name, handler);
        }
    }
}