using UnityEngine;
using System.Collections;

public class VRIntTest : VRIntBase {

    public float maxHoverTime;

    public override void Hover()
    {
        base.Hover();

        if (hoverTime > maxHoverTime)
        {
            hoverTime = maxHoverTime;
        }
    }
}
