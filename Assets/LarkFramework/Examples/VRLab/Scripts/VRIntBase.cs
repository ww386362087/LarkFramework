using UnityEngine;
using System.Collections;

public class VRIntBase : MonoBehaviour {

    [HideInInspector]
    public float hoverTime;

    void Awake()
    {
        transform.tag = "VRInteraction";
    }

    /// <summary>
    /// 焦点悬停
    /// </summary>
    public virtual void Hover()
    {
        hoverTime += Time.deltaTime;
    }

    /// <summary>
    /// 移出
    /// </summary>
    public virtual void Exit()
    {
        hoverTime = 0;
    }

    /// <summary>
    /// 执行
    /// </summary>
    public virtual void UseEnter()
    {
        print("UseEnter");
    }
}
