using UnityEngine;
using System.Collections;

public class MoveCtrl : MonoBehaviour {

    public Transform mainCam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        ShowCamForward(h,v);
    }

    private void ShowCamForward(float h, float v)
    {
        var a = Vector3.Scale(mainCam.forward, new Vector3(1, 0, 1)).normalized;
        var b = v * a + h * mainCam.right;

        Debug.DrawLine(transform.position, a,Color.blue);
        Debug.DrawLine(transform.position, b, Color.red);

    }

    private void Move(Vector3 move)
    {
        if (move.magnitude > 1f) move.Normalize();
    }
}
