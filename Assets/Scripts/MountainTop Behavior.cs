using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainTopBehavior : MonoBehaviour
{
    [SerializeField] protected Canvas FinalCanvas;

    // Start is called before the first frame update
    void Start()
    {
        FinalCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        FinalCanvas.enabled = true;
    }
}
