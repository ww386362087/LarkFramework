using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// 测试用通知中心
/// </summary>
public class TestNotificationCenter {

    /// <summary>
    /// 通知中心单例
    /// </summary>
    private static TestNotificationCenter instance = null;
    public static TestNotificationCenter Get()
    {
        if (instance == null)
        {
            instance = new TestNotificationCenter();
            return instance;
        }
        return instance;
    }

    internal void AddEventListener(string v, Action<TestNotification> changeColor)
    {
        throw new NotImplementedException();
    }


    /// <summary>
    /// 存储事件的字典
    /// </summary>
    private Dictionary<string, TestNotification> eventListeners
        = new Dictionary<string, TestNotification>();

    /// <summary>
    /// 注册事件
    /// </summary>
    /// <param name="eventKey">事件Key</param>
    /// <param name="eventListener">事件监听器</param>
    public void AddEventListener(string eventKey, TestNotification eventListener)
    {
        if (!eventListeners.ContainsKey(eventKey))
        {
            eventListeners.Add(eventKey, eventListener);
        }
    }

    /// <summary>
    /// 移除事件
    /// </summary>
    /// <param name="eventKey">事件Key</param>
    public void RemoveEventListener(string eventKey)
    {
        if (!eventListeners.ContainsKey(eventKey))
            return;

        eventListeners[eventKey] = null;
        eventListeners.Remove(eventKey);
    }

    /// <summary>
    /// 分发事件
    /// </summary>
    /// <param name="eventKey">事件Key</param>
    /// <param name="notific">通知</param>
    public void DispatchEvent(string eventKey, TestNotification notific)
    {
        if (!eventListeners.ContainsKey(eventKey))
            return;
        //eventListeners[eventKey](notific);
    }

    /// <summary>
    /// 分发事件
    /// </summary>
    /// <param name="eventKey">事件Key</param>
    /// <param name="sender">发送者</param>
    /// <param name="param">通知内容</param>
    public void DispatchEvent(string eventKey, GameObject sender, object param)
    {
        if (!eventListeners.ContainsKey(eventKey))
            return;
        //eventListeners[eventKey](new TestNotification(sender, param));
    }

    /// <summary>
    /// 分发事件
    /// </summary>
    /// <param name="eventKey">事件Key</param>
    /// <param name="param">通知内容</param>
    public void DispatchEvent(string eventKey, object param)
    {
        if (!eventListeners.ContainsKey(eventKey))
            return;
        //eventListeners[eventKey](new TestNotification(param));
    }

    /// <summary>
    /// 是否存在指定事件的监听器
    /// </summary>
    public bool HasEventListener(string eventKey)
    {
        return eventListeners.ContainsKey(eventKey);
    }
}
