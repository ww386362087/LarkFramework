using UnityEngine;
using System.Collections;
using LarkFramework.Test;

public class Test01_Rec : MonoBehaviour {

	// Use this for initialization
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "ApplyDamage");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ApplyDamage(Notification note)
    {
        Debug.Log("从:" + note.sender + ",接收一个信息内容:" + (string)note.data + ", 通知名称为:" + note.name);
    }
}
