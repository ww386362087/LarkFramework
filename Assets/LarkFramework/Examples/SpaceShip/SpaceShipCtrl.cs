using UnityEngine;
using System.Collections;

public class SpaceShipCtrl : MonoBehaviour {

    public float MaxThrust;
    public float MinThrust;
    public float FullThrustTime;

    public float RotateMoment;
    public bool UseMoment;

    public float R_Thrust;
    public Vector3 R_RotateMoment;
    public float R_LastRotation;
    public Quaternion R_AtMomentAngle;

    void Update()
    {
        SetMaxThrust();
        SetZeroThrust();

        AddThrust();
        MinishThrust();

        SwitchRotateMoment();
        RotateMomentCtrl();
    }

    private void SwitchRotateMoment()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            UseMoment = !UseMoment;
            if (UseMoment)
            {
                R_AtMomentAngle = transform.rotation;
            }
        }
    }

    private void RotateMomentCtrl()
    {
        if (UseMoment)
        {
            if (R_RotateMoment.x!=0 || R_RotateMoment.y!=0||R_RotateMoment.z!=0)
                return;

            var temp = Quaternion.Angle(R_AtMomentAngle,transform.rotation);

            Debug.Log(temp - R_LastRotation);

            if ((temp - R_LastRotation) > 0)
            {
                var b = GetComponent<ConstantForce>().relativeTorque = new Vector3(-RotateMoment*((temp - R_LastRotation)/180)*180, 0, 0);
            }
            else
            {
                GetComponent<ConstantForce>().relativeTorque = new Vector3(RotateMoment*((temp - R_LastRotation) / 180)*180, 0, 0);
            }

            R_LastRotation = temp;
        }
    }

    private void SetMaxThrust()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(SetThust_Continue(true));
        }
    }

    private void SetZeroThrust()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(SetThust_Continue(false));
        }
    }

    private void AddThrust()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            SetThrust(R_Thrust+(MaxThrust / FullThrustTime) * Time.deltaTime);
        }
    }

    private void MinishThrust()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            SetThrust(R_Thrust - ((MaxThrust / FullThrustTime) * Time.deltaTime));
        }
    }

    IEnumerator SetThust_Continue(bool isAdd)
    {
        if (isAdd)
        {
            var temp = (FullThrustTime - FullThrustTime * (R_Thrust / MaxThrust));
            Debug.Log(temp);
            for (float i = 0; i <= temp; i += Time.deltaTime)
            {
                SetThrust(MaxThrust * (i / FullThrustTime));
                yield return null;
            }
        }
        else
        {
            var temp = ( FullThrustTime * (R_Thrust / MaxThrust));
            var NowThrust = R_Thrust;
            for (float i = temp; i >= 0; i -= Time.deltaTime)
            {
                SetThrust(NowThrust * (i / FullThrustTime));
                Debug.Log((i / FullThrustTime));
                yield return null;
            }
        }
    }

    private void SetThrust(float newThrust)
    {
        R_Thrust = Mathf.RoundToInt(Mathf.Clamp(newThrust, MinThrust, MaxThrust) * 100) * 0.01f;
    }

}
