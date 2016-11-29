using UnityEngine;
using System.Collections;

public class UIStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UIPage.ShowPage<MainView>();
	}
}
