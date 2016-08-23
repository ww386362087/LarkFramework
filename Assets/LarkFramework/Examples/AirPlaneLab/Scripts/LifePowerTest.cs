using UnityEngine;
using System.Collections;

public class LifePowerTest : MonoBehaviour {

    public Transform[] windPos;
    public float selfSpeed;

    public Transform rudder;

    public AnimationCurve xxx;
    public Transform lifepos;

    public float maxRudderAngle;
    public float maxAngleTime;

    public float wingCI;
    public float wingA;

    public float rudderCI;
    public float rudderA;

    private Quaternion quate;
    private float temp;

	// Use this for initialization
	void Start () {
        quate = rudder.transform.localRotation;
    }
	
	// Update is called once per frame
	void Update () {
        DrawWind();
        RudderAni();
        CheckAngle();
    }

    private void CheckAngle()
    {
        //获取当前速度分量
        var speedray = rudder.transform.forward;
        var temp = transform.InverseTransformDirection(speedray);
        //投射到飞机平面的攻角
        Vector3 horizzontalSpeed = new Vector3(temp.x, 0, temp.z);
        var horizzon = System.Math.Sign(-speedray.y) * Vector3.Angle(speedray, horizzontalSpeed);

        var t = Quaternion.AngleAxis(90 - horizzon, transform.right);

        lifepos.rotation = Quaternion.Euler(lifepos.rotation.x + 90 - horizzon, lifepos.rotation.y, lifepos.rotation.z);

        Debug.DrawRay(lifepos.position, lifepos.up * -5, Color.red);
        Debug.DrawRay(lifepos.position, transform.forward * -5, Color.green);
    }

    private void RudderAni()
    {
        if (Input.GetAxis("AirPitch") != 0)
        {
            if (Input.GetAxis("AirPitch") > 0)
            {
                temp += maxRudderAngle / maxAngleTime * Time.deltaTime;
                temp = Mathf.Clamp(temp, quate.x - maxRudderAngle, quate.x+maxRudderAngle);
            }
            else
            {
                temp -= maxRudderAngle / maxAngleTime * Time.deltaTime;
                temp = Mathf.Clamp(temp, quate.x - maxRudderAngle, quate.x + maxRudderAngle);
            }
        }
        else
        {
            if (temp > quate.x)
            {
                if (temp - maxRudderAngle / maxAngleTime * Time.deltaTime > quate.x)
                {
                    temp -= maxRudderAngle / maxAngleTime * Time.deltaTime;
                }
                else
                {
                    temp = quate.x;
                }
            }
            else
            {
                if (temp + maxRudderAngle / maxAngleTime * Time.deltaTime < quate.x)
                {
                    temp += maxRudderAngle / maxAngleTime * Time.deltaTime;
                }
                else
                {
                    temp = quate.x;
                }
            }
        }

        rudder.transform.localRotation = Quaternion.Euler(temp, quate.y, quate.z);
    }

    private void DrawWind()
    {
        for (int i = 0; i < windPos.Length; i++)
        {
            Debug.DrawRay(windPos[i].position, windPos[i].forward * -5, Color.blue);
        }
    }
}
