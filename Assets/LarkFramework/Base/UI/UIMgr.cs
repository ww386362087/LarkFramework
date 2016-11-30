using UnityEngine;
using System.Collections;
using LarkFramework.UI;

public class UIMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ViewMgr.ShowView<MainView>();
	}
}
