using UnityEngine;
using System.Collections;

public class WingManager : MonoBehaviour {

    public float r_liftPower;

    private Rigidbody rig;
    private AirPlaneBase airPlaneBase;

    void Start()
    {
        airPlaneBase = transform.parent.GetComponent<AirPlaneBase>();
        rig = transform.parent.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        CreateLiftPower();
    }

    private void CreateLiftPower()
    {
        rig.AddForceAtPosition(airPlaneBase.liftCenter.up * r_liftPower, airPlaneBase.liftCenter.position);
    }
}
