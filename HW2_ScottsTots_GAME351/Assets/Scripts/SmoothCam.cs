using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCam : MonoBehaviour
{
    //assigns a public tranform which is the point on the car that the camera follows. It is a list of the three different transforms of the different cars.
    //offset is a vector3 that effect where the camera is relative to the follow point. I have found that only giving a y offset works the best.
    //x and z offsets cause the car to come off center so i put the follow point attach to the car and behind it.
    public Transform[] followPoints = new Transform[3];
    public Transform[] crafts = new Transform[3];

    public Vector3 offset;
    public int selected = 0;
    bool pressed = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        //every frame it sets the cameras position to the follow points position plus an offest.
        this.transform.position = followPoints[selected].position + offset;
        //It copys the y orientation of the craft. I had to use vector3 to make it work so it copies its own x and z orientation to that it stays level.

        this.transform.LookAt(crafts[selected].position);

        //if statement is checking if the c button has been pressed. the pressed bool is used as a lockout so c must be released before the camera swaps again. this prevents rapid swapping every frame the key is held.
        if (Input.GetKey(KeyCode.C) == true && pressed == false)
        {
            //iterates and loops back through an intergar this will be tied to array use.
            if(selected < 2)
            {
                selected ++;
            }
            else
            {
                selected = 0;
            }
            pressed = true;
        }

        if (Input.GetKey(KeyCode.C) == false)
        {
            pressed = false;
        }
    }
}
