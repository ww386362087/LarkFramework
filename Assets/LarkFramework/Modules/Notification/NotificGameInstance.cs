using UnityEngine;
using System.Collections;
using LarkFramework;

public class NotificGameInstance : MonoBehaviour {

    public GameObject test;
    public int num;

	// Use this for initialization
	void Start () {
        if (SingletonHelper<NotificationCenter>.Create() == null)
        {
            Debug.Log("Create NotificationCenter Error");
        }

        if (test != null)
        {
            for (int i = 0; i < num; i++)
            {
                Instantiate(test, transform.position, transform.rotation);
            }
        }
    }
}
