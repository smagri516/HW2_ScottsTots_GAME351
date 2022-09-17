using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCam : MonoBehaviour
{
    //assigns a public tranform which is the point on the car that the camera follows.
    //offset is a vector3 that effect where the camera is relative to the follow point. I have found that only giving a y offset works the best.
    //x and z offsets cause the car to come off center so i put the follow point attach to the car and behind it.
    public Transform craft;
    public Vector3 offset;


    // Update is called once per frame
    void FixedUpdate()
    {
        //every frame it sets the cameras position to the follow points position plus an offest.
        this.transform.position = craft.position + offset;
        //It copys the y orientation of the craft. I had to use vector3 to make it work so it copies its own x and z orientation to that it stays level.
        Vector3 newRotation = new Vector3(this.transform.eulerAngles.x, craft.transform.eulerAngles.y, this.transform.eulerAngles.z);
        this.transform.eulerAngles = newRotation;
    }
}
