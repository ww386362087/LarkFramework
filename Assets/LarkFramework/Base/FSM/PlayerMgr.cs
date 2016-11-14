using UnityEngine;
using System.Collections;
using LarkFramework;

public class PlayerMgr : Actor {

    [SerializeField]
    float radius=0.5f;

    private CapsuleCollider col;
    private bool contact;

    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        if (col != null)
        {
            radius = col.radius;
        }
    }

    void Update()
    {
        Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        CheckPenetrate();
    }

    public void Move(float horizontal,float vertical)
    {
        print(horizontal + " " + vertical);
    }

    private void CheckPenetrate()
    {
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
