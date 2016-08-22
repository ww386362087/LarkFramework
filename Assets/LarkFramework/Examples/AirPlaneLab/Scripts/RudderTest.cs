using UnityEngine;
using System.Collections;

public class RudderTest : MonoBehaviour {

    public Transform ctrlCenter;
    public Transform liftCenter;

    public Transform RudderWing;
    public Transform RudderMain;

    public float maxAngle;
    public float fullAngleTime;

    private Quaternion n_RudderMainRotation;
    private int isForward;
    private int isRight;
    private float dotForwardAngle;
    private float dotUpAngle;

    //是否复位
    private bool isReset;   

    private float r_UseRudderTime;

    // Use this for initialization
    void Start () {
        n_RudderMainRotation = RudderMain.rotation;

        JudgeHorV();

        JudgeFlip();
    }

    /// <summary>
    /// 判断当前机翼相对控制中心是水平还是垂直以及偏转角度
    /// </summary>
    public void JudgeHorV()
    {
        dotForwardAngle = Vector3.Dot(ctrlCenter.forward, transform.forward);

        dotUpAngle = Vector3.Dot(ctrlCenter.up, transform.up);
        if (dotUpAngle < 0.01f && dotUpAngle > -0.01f)
        {
            dotUpAngle = 0;
        }
    }

    /// <summary>
    /// 判断机翼位于升力中心的相对位置
    /// 根据相对位置处理机翼偏转方向和角度
    /// </summary>
    public void JudgeFlip()
    {
        //正为前，负为后
        isForward = Vector3.Dot(liftCenter.forward, transform.position)>0?1:-1;
        //正为右，负为左
        isRight = Vector3.Cross(liftCenter.forward, transform.position).y>0?1:-1;
    }
	
	// Update is called once per frame
	void Update () {
        ChangeRudderAni(Input.GetAxis("AirPitch"), Input.GetAxis("AirRoll"), 0);
    }

    public void ChangeRudderAni(float airPitch, float airRoll,float airYaw)
    {
        var a = airPitch - airPitch * 0.5f * airRoll;
        var b = airRoll - airRoll * 0.5f * airPitch;
        print(a + "|" + b);

        //var a = airPitch-airPitch * 0.33f*airRoll- airPitch*0.33f* airYaw;
        //var b = airRoll-airRoll * 0.33f* airPitch- airRoll*0.33f*airYaw;
        //var c = airYaw - airYaw * 0.33f * airRoll - airYaw * 0.33f * airPitch;

        //print(a+"|"+b+"|"+c);

        //if (airPitch != 0)
        //{
        //    r_UseRudderTime = Mathf.Clamp(r_UseRudderTime + Time.deltaTime* airPitch, -fullAngleTime, fullAngleTime);
        //}
        //else
        //{
        //    if (r_UseRudderTime > 0)
        //    {
        //        r_UseRudderTime = r_UseRudderTime - Time.deltaTime > 0 ? r_UseRudderTime - Time.deltaTime : 0;
        //    }
        //    if (r_UseRudderTime < 0)
        //    {
        //        r_UseRudderTime = r_UseRudderTime + Time.deltaTime < 0 ? r_UseRudderTime + Time.deltaTime : 0;
        //    }
        //}

        //if (airRoll != 0)
        //{

        //}

        //RotateRudder(r_UseRudderTime / fullAngleTime);
    }

    public void RotateRudder(float axis)
    {
        RudderMain.rotation = n_RudderMainRotation * Quaternion.Euler(maxAngle * axis * dotForwardAngle* dotUpAngle, 0, 0);
    }

    void FixedUpdate()
    {
        ChangeRudder();
    }

    public void ChangeRudder()
    {

    }
}
