using UnityEngine;
using System.Collections;

public class AirPlaneBase : MonoBehaviour {

    public Transform thrustCenter;
    public Transform massCenter;
    public Transform liftCenter;

    public WingManager wingMgr;

    [HideInInspector]
    public float airSpeed;

    public float TestSpeed;

    private Rigidbody rig;

	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>();
        rig.centerOfMass= massCenter.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        GetAirSpeed();
        SetLiftPower();
    }

    private void GetAirSpeed()
    {
        airSpeed = Mathf.Round(rig.velocity.sqrMagnitude*100)*0.01f;
    }

    private void SetLiftPower()
    {
        wingMgr.r_liftPower = Mathf.Round(0.5f * 1.3f * TestSpeed * TestSpeed * wingMgr.wingArea * 0.2f);
    }
}
