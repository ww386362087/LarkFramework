using UnityEngine;
using System.Collections;
using LarkFramework;

public class test {

    private test()
    {
        GameInstance.Instance().onUpdate += Update;
    }

    void Update()
    {
        Debug.Log("1111");
    }
}
