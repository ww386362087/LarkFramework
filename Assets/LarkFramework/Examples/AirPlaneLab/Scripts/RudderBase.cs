using UnityEngine;
using System.Collections;

public class RudderBase : MonoBehaviour {

    public Transform rudder;
    /// <summary>
    /// 偏转角度
    /// </summary>
    public float fullRudderAngle;

    /// <summary>
    /// 满舵改变推力
    /// </summary>
    public float fullRudderPower;
    /// <summary>
    /// 从0-100%推力所用时间
    /// </summary>
    public float fullRudderTime;

    public float r_RudderPower;

    private AirPlaneBase airPlaneBase;
    private Rigidbody rig;

    private float addRudderPower;

    /// <summary>
    /// 判断正反操作
    /// </summary>
    private int isFlip;

    void Start () {
        airPlaneBase = transform.parent.transform.parent.GetComponent<AirPlaneBase>();
        rig = transform.parent.transform.parent.GetComponent<Rigidbody>();

        addRudderPower = fullRudderPower / fullRudderTime;

    }
	
	void Update () {
        SerRudderAngle();
    }

    private void SerRudderAngle()
    {
        var temp = -fullRudderAngle * (r_RudderPower/fullRudderPower);
        rudder.localRotation= (Quaternion.Euler(temp, rudder.localRotation.y, rudder.localRotation.z));
    }

    void FixedUpdate()
    {
        ChangeRudderPower();
        ChangeRudderPower2();
    }

    private void ChangeRudderPower()
    {
        if (Input.GetAxis("Vertical")!=0)
        {
            r_RudderPower = fullRudderPower * (Input.GetAxis("Vertical"));

            rig.AddForceAtPosition(transform.up * r_RudderPower, transform.position);
        }
    }

    private void ChangeRudderPower2()
    {
        if (Input.GetAxis("Horizontal")!=0)
        {
            isFlip = (transform.localPosition.x > 0) ? 1 : -1;
            r_RudderPower = fullRudderPower * (Input.GetAxis("Horizontal")) * isFlip;

            rig.AddForceAtPosition(transform.up * r_RudderPower, transform.position);

            Debug.DrawRay(transform.position, transform.up * r_RudderPower/1000,Color.blue);
        }
    }
}
