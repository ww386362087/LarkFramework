using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public AirPlaneBase airPlaneBase;
    public RudderBase leftRudder;
    public RudderBase rightRudder;

    public Text thrust;
    public Text rudder;

    private EnglineBase englineBase;

	// Use this for initialization
	void Start () {
        englineBase = airPlaneBase.GetComponentInChildren<EnglineBase>();

    }
	
	// Update is called once per frame
	void Update () {
        thrust.text = "Thrust:"+ englineBase.r_Thrust.ToString();
        rudder.text = "left:"+leftRudder.r_RudderPower+"  right:"+rightRudder.r_RudderPower;
    }
}
