using UnityEngine;
using System.Collections;
using LarkFramework;

public class TestManager : SingletonMono<TestManager>
{

    public void Init()
    {
        print("TestManager:Init");
    }

    public void OnUpdate()
    {
        print("TestManager:Update");

        SendMessage();
    }

    public void Reset()
    {
        print("TestManager:Reset");
    }

    private void SendMessage()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("Hello!");
            NotificationCenter.DefaultCenter().PostNotification(this, "ApplyDamage", "HelloWorld!");
        }
    }
}
