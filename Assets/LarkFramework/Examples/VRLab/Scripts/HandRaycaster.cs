using UnityEngine;
using System.Collections;

public class HandRaycaster : MonoBehaviour {

	void Update () {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, 10))
        {
            print("touch!");
        }
	}

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*10);
    }
}
