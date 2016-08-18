using UnityEngine;
using System.Collections;

public class AirPlaneBase : MonoBehaviour {

    public Transform thrustCenter;
    public Transform massCenter;
    public Transform liftCenter;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().centerOfMass= massCenter.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
