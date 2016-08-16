using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HandRaycaster : MonoBehaviour {

    public Camera mainCam;
    public Transform tagReticle;
    public Image background;

    public float checkDistance;

    private Vector3 normalScale;

    void Start()
    {
        normalScale = tagReticle.transform.localScale;
    }

	void Update () {
        Vector3 fwd = mainCam.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, fwd, out hit, checkDistance))
        {
            showUI(hit.point, hit.distance);
            background.enabled = true;
        }
        else
        {
            background.enabled = false;
        }
	}

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(mainCam.transform.position, mainCam.transform.TransformDirection(Vector3.forward)*10);
    }

    private void showUI(Vector3 hitPos,float distance)
    {
        tagReticle.transform.position = hitPos;
        tagReticle.transform.localScale = normalScale * distance;
    }
}
