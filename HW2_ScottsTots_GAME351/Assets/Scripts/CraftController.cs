using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftController : MonoBehaviour
{
    Rigidbody craft;
    public float mult;
    public float moveForce;
    public float turnTorque;

    void Start()
    {
        craft = GetComponent<Rigidbody>();
    }

    public Transform[] anchors = new Transform[3];
    public RaycastHit[] hits = new RaycastHit[3];

    void FixedUpdate()
    {
        for (int i = 0; i < 3; i++)
            ApplyF(anchors[i], hits[i]);

        craft.AddForce(Input.GetAxis("Vertical") * moveForce * transform.forward);
        craft.AddTorque(Input.GetAxis("Horizontal") * turnTorque * transform.up);

    }

    void ApplyF(Transform anchor, RaycastHit hit)
    {
        if (Physics.Raycast(anchor.position, -anchor.up, out hit))
        {
            float force = 0;
            force = Mathf.Abs(1 / (hit.point.y - anchor.position.y));
            craft.AddForceAtPosition(transform.up * force * mult, anchor.position, ForceMode.Acceleration);
        }
    }

}