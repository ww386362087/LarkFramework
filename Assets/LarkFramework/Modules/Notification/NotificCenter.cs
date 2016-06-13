using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void OnDelegateFunc(Notific node);

public class NotificCenter : MonoBehaviour {
    private static NotificCenter _Instance = null;
    private Dictionary<string, OnDelegateFunc> _mapFun = new Dictionary<string, OnDelegateFunc>();

    public static NotificCenter GetInstance()
    {
        if (_Instance == null)
        {
            _Instance = new NotificCenter();
        }
        return _Instance;
    }

    public void AddNotificationEvent(string key, OnDelegateFunc func)
    {
        if (!_mapFun.ContainsKey(key))
        {
            _mapFun[key] = null;
        }
        _mapFun[key] += func;
    }

    public void RemoveNotificationEvent(string key, OnDelegateFunc func)
    {
        if (!_mapFun.ContainsKey(key))
        {
            _mapFun[key] = null;
        }
        _mapFun[key] -= func;
    }

    public void RemoveAllNotificationEvent(string key)
    {
        _mapFun[key] = null;
    }

    public void PostNotificationEvent(string key, Notific node = null)
    {
        if (!_mapFun.ContainsKey(key))
        {
            return;
        }
        _mapFun[key](node);
    }
}

public class Notific
{
    public Component sender;
    public object data;
    public string name;

    public Notific(object aData) { data = aData; }

    public Notific(Component aSender, string aName, object aData)
    {
        sender = aSender;
        name = aName;
        data = aData;
    }
} 
