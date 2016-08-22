using UnityEngine;
using System.Collections;

public class LifePowerTest : MonoBehaviour {

    public Transform[] windPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        DrawWind();

    }

    private void RudderAni()
    {

    }

    private void DrawWind()
    {
        for (int i = 0; i < windPos.Length; i++)
        {
            Debug.DrawRay(windPos[i].position, windPos[i].forward * -5, Color.blue);
        }
    }
}
