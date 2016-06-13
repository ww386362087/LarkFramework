using UnityEngine;
using System.Collections;
using LarkFramework;

public class test1 : MonoBehaviour {

    private bool open;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(name + " send msg");
            NotificCenter.GetInstance().PostNotificationEvent("Hello",new Notific(1));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            open = !open;
        }

        if (open)
        {
            Debug.Log("open send msg");

            NotificCenter.GetInstance().PostNotificationEvent("Hello", new Notific(1));
        }
	}
}
