using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainTopBehavior : MonoBehaviour
{
    public GameObject FinalCanvas;
    

    // Start is called before the first frame update
    void Start()
    {
        FinalCanvas.SetActive(false);
        
    }

    // Update is called once per frame
    public void ShowFinalCanvas()
    {
       FinalCanvas.SetActive(true);
       Debug.Log("Player is in the air!");
    }
}
