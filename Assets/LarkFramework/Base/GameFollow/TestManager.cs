using UnityEngine;
using System.Collections;
using LarkFramework.GameFollow;
using LarkFramework;

public class TestManager : ManagerBase<TestManager>
{

    // Use this for initialization
    public override void Init()
    {
        print(GetType().Name+"this is TestManager Start");
    }

    // Update is called once per frame
    public override void OnUpdate()
    {
        print(GetType().Name+"this is TestManager Update");
    }
}
