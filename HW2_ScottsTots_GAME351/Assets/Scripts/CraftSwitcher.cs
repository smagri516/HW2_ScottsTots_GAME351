using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSwitcher : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    public GameObject craft1;
    public GameObject craft2;
    public GameObject craft3;


    // Start is called before the first frame update
    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);

        craft1.GetComponent<Craft1Controller>().enabled = true;
        craft2.GetComponent<Craft2Controller>().enabled = false;
        craft3.GetComponent<Craft3Controller>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("1Key"))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);


            craft1.GetComponent<Craft1Controller>().enabled = true;
            craft2.GetComponent<Craft2Controller>().enabled = false;
            craft3.GetComponent<Craft3Controller>().enabled = false;


        }

        if (Input.GetButtonDown("2Key"))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);

            craft1.GetComponent<Craft1Controller>().enabled = false;
            craft2.GetComponent<Craft2Controller>().enabled = true;
            craft3.GetComponent<Craft3Controller>().enabled = false;
        }

        if (Input.GetButtonDown("3Key"))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);

            craft1.GetComponent<Craft1Controller>().enabled = false;
            craft2.GetComponent<Craft2Controller>().enabled = false;
            craft3.GetComponent<Craft3Controller>().enabled = true;
        }
    }
}
