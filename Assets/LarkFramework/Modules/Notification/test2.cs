using UnityEngine;
using System.Collections;
using LarkFramework;
using System;

public class test2 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        NotificCenter.GetInstance().AddNotificationEvent("Hello", func);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void func(Notific node)
    {
        Debug.Log("I get msg:"+(int)node.data);
    }

    void OnDestroy()
    {
        NotificCenter.GetInstance().RemoveAllNotificationEvent("Hello");
    }
}
