using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAtMultiplePos : MonoBehaviour
{
    public GameObject objectToSpawn;
    //public Vector3[] spawnPoints;
    public GameObject[] spawnPoints;
    //private Rigidbody rb; 

    void Start()
    {
        foreach (GameObject spawnPoint in spawnPoints)
        {
            Instantiate(objectToSpawn, spawnPoint.transform.position, Quaternion.identity);
            //rb = objectToSpawn.GetComponent<Rigidbody>();
            //rb.velocity = Vector3.zero;
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
