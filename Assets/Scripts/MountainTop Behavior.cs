using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainTopBehavior : MonoBehaviour
{
    public GameObject FinalCanvas;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        FinalCanvas.SetActive(false);
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > 17.8)
        {
            FinalCanvas.SetActive(true);
            Debug.Log("Player is in the air!");
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FinalCanvas.SetActive(true);
            Debug.Log("Final Collider entered");
        }
    }*/
}
