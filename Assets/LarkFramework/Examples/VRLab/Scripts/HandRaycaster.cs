using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HandRaycaster : MonoBehaviour {

    public Camera mainCam;
    public Transform tagReticle;
    public Image background;
    public Image selectionBar;

    public float checkDistance;

    private Vector3 normalScale;
    private VRIntTest lastVRIntTest;

    void Start()
    {
        normalScale = tagReticle.transform.localScale;
    }

	void Update () {
        Vector3 fwd = mainCam.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, fwd, out hit, checkDistance))
        {
            showUI(hit);
            background.enabled = true;
        }
        else
        {
            background.enabled = false;

            if (lastVRIntTest != null)
            {
                lastVRIntTest.hoverTime = 0;
                lastVRIntTest = null;
                selectionBar.fillAmount = 0;
            }
        }
	}

    void OnDrawGizmos() 
    {
        Gizmos.DrawRay(mainCam.transform.position, mainCam.transform.TransformDirection(Vector3.forward)*10);
    }

    private void showUI(RaycastHit hit)
    {
        tagReticle.transform.position = hit.point;
        tagReticle.transform.localScale = normalScale *hit.distance;

        if (hit.transform.tag.Equals("VRInteraction"))
        {
            var temp = hit.collider.GetComponent<VRIntTest>();
            temp.Hover();

            selectionBar.fillAmount = temp.hoverTime / temp.maxHoverTime;

            lastVRIntTest = temp;
        }
    }
}
