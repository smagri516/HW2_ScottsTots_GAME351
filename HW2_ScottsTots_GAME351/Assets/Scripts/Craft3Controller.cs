using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft3Controller : MonoBehaviour
{
    //creates a bunch of public variables so they can be altered from the editor. Mult is used for the hovering, moveforce is to move forward, turntorque effect the turning.
    //creates a rigidbody on the craft as well
    Rigidbody craft;
    public float mult;
    public float moveForce;
    public float turnTorque;

    void Start()
    {
        //Assigns the rigidbody of the craft to a variable called craft for later calling.
        craft = GetComponent<Rigidbody>();
    }
    // creates two 3 value arrays that hold 3 coordinate vectors. The first holds the locations of points on the craft where it hovers from called anchors.
    // The other array holds the values of locations where raycasts contact terrain.
    public Transform[] anchors = new Transform[3];
    public RaycastHit[] hits = new RaycastHit[3];

    void FixedUpdate()
    {
        //every frame regardless of framerate (thanks to fixedupdate) the following gets called
        //the for loop iterates up to three every frame. every iteration it calls the function applyF using i in the parameters.
        for (int i = 0; i < 3; i++)
            ApplyF(anchors[i], hits[i]);
        //this adds forces based on the vertical and horizontal axis which have input automatically mapped to wasd/arrow keys.
        //when it multiplies it will add a direction forward/backward or right/left. if no key is pressed it will return 0 which will 0 out the equation and no force will be applied.
        if (GameObject.Find("Main Camera").GetComponent<SmoothCam>().selected == 2)
        {
            craft.AddForce(Input.GetAxis("Vertical") * moveForce * transform.forward);
            craft.AddTorque(Input.GetAxis("Horizontal") * turnTorque * transform.up);
        }

    }
    //The applyF function is what provides the upward force for levitation.
    void ApplyF(Transform anchor, RaycastHit hit)
    {
        if (Physics.Raycast(anchor.position, -anchor.up, out hit))
        {
            //sets the force variable at 0
            float force = 0;
            //Recipricates the distance between the anchor and the terrain and multiplies that into the thrust so that as the craft gets farther from the ground the force lessens.

            force = Mathf.Abs(1 / (hit.point.y - anchor.position.y));
            //This force that levitates the craft uses AddForce at position because it wants to add force to the main craft object, but at the location of the anchor objects.
            craft.AddForceAtPosition(transform.up * force * mult, anchor.position, ForceMode.Acceleration);

        }

    }

}