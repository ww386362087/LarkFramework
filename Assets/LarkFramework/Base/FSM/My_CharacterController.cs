using UnityEngine;
using System.Collections;

public class My_CharacterController : MonoBehaviour {

    [SerializeField]
    float radius = 0.5f;

    private bool contact;

    // Update is called once per frame
    void Update () {

    contact = false;

        foreach (Collider col in Physics.OverlapSphere(transform.position, radius))
        {
            Vector3 contactPoint = col.ClosestPointOnBounds(transform.position);

            DebugDraw.DrawMarker(contactPoint, 2.0f, Color.red, 0.0f, false);

            Vector3 v = transform.position - contactPoint;

            transform.position += Vector3.ClampMagnitude(v, Mathf.Clamp(radius - v.magnitude, 0, radius));

            contact = true;
        }
    }
	 
	void OnDrawGizmos()
{
    Gizmos.color = contact ? Color.cyan : Color.yellow;
    Gizmos.DrawWireSphere(transform.position, radius);
}
}
