using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCrafts : MonoBehaviour
{
    int numCrafts = 0;
    public GameObject craftType1;
    public GameObject craftType2;
    public GameObject craftType3;

    public Transform[] spawnLocations = new Transform[7];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (numCrafts < 6)
        {
            Transform cur_spawn = spawnLocations[numCrafts];
            

            if (Input.GetButtonDown("1Key"))
            {
                Instantiate(craftType1, cur_spawn.transform.position, craftType1.transform.rotation);
                Debug.Log(cur_spawn);
                Debug.Log(cur_spawn.transform.position);
                Debug.Log(numCrafts);
                numCrafts++;

            }

            if (Input.GetButtonDown("2Key"))
            {
                Instantiate(craftType2, cur_spawn.transform.position, craftType2.transform.rotation);
                Debug.Log(cur_spawn);
                Debug.Log(cur_spawn.transform.position);
                Debug.Log(numCrafts);
                numCrafts++;

            }

            if (Input.GetButtonDown("3Key"))
            {
                Instantiate(craftType3, cur_spawn.transform.position, craftType3.transform.rotation);
                Debug.Log(cur_spawn);
                Debug.Log(cur_spawn.transform.position);
                Debug.Log(numCrafts);
                numCrafts++;

            }
        }
        else
        {
            Debug.Log("Already have 10 spawns");
        }
        
    }
}
