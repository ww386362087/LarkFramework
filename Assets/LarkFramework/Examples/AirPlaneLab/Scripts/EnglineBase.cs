using UnityEngine;
using System.Collections;

public class EnglineBase : MonoBehaviour {

    public Transform propeller;
    /// <summary>
    /// 螺旋桨最大转速
    /// </summary>
    public float fullPropellerRPM;

    public float mass;

    public float maxThrust;
    public float minThrust;
    /// <summary>
    /// 从min到max推力需要的时间
    /// </summary>
    public float fullTime;

    public float r_Thrust;
    public bool r_Active;

    private AirPlaneBase airPlaneBase;
    private Rigidbody rig;

    private float addThrust;

    void Start()
    {
        airPlaneBase = transform.parent.GetComponent<AirPlaneBase>();
        rig = transform.parent.GetComponent<Rigidbody>();

        addThrust = (maxThrust - minThrust) / fullTime;
    }

    void Update()
    {
        PropellerAnimation();
    }

    private void PropellerAnimation()
    {
        propeller.Rotate(Vector3.forward * fullPropellerRPM * (r_Thrust/maxThrust)* Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            r_Thrust = maxThrust;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            r_Thrust = 0;
        }

        if (r_Active)
        {
            ChangeThrust();
        }
    }

    private void ChangeThrust()
    {
        if (Input.GetAxis("Thrust") != 0)
        {
            r_Thrust += addThrust * Input.GetAxis("Thrust") * Time.fixedDeltaTime;
            r_Thrust = Mathf.Clamp(r_Thrust, minThrust, maxThrust);
        }

        rig.AddForceAtPosition(airPlaneBase.thrustCenter.forward * r_Thrust, airPlaneBase.thrustCenter.position);
    }
}
