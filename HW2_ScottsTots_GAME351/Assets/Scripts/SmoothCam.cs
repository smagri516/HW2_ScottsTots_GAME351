using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCam : MonoBehaviour
{
    public Transform craft;
    public Vector3 offset;


    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = craft.position + offset;
        Vector3 newRotation = new Vector3(this.transform.eulerAngles.x, craft.transform.eulerAngles.y, this.transform.eulerAngles.z);
        this.transform.eulerAngles = newRotation;
    }
}
