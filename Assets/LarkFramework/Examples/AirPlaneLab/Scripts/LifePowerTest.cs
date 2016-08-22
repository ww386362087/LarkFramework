using UnityEngine;
using System.Collections;

public class LifePowerTest : MonoBehaviour {

    public Transform[] windPos;
    public float selfSpeed;

    public Transform rudder;

    public float maxRudderAngle;

    public float wingCI;
    public float wingA;

    public float rudderCI;
    public float rudderA;

    private Quaternion quate;

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

        //获取当前
    }

    private void RudderAni()
    {
        rudder.transform.localRotation = Quaternion.Euler(quate.x + maxRudderAngle* Input.GetAxis("AirPitch"), quate.y, quate.z);
    }

    private void DrawWind()
    {
        for (int i = 0; i < windPos.Length; i++)
        {
            Debug.DrawRay(windPos[i].position, windPos[i].forward * -5, Color.blue);
        }
    }
}
