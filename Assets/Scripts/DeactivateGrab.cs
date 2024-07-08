using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;



/* 
 * This script detects whether the object collides with the trigger and if so, it deactivate the XRGrabInteractable script
 * and set the desired interaction layer mask
 */

public class Stonebehavior : MonoBehaviour
{
    private XRGrabInteractable grabComp;

    [Tooltip("The layer that's switched to")]
    public InteractionLayerMask targetLayer = 0;


    // Start is called before the first frame update
    void Start()
    {
        grabComp = GetComponent<XRGrabInteractable>();
        
        grabComp.interactionLayers = InteractionLayerMask.GetMask("Default");
        Debug.Log(LayerMask.GetMask("Raycasts"));
        Debug.Log(LayerMask.GetMask("test"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Deactivate Grab script
        grabComp.enabled = false;

        // Set target layer
        SetTargetLayer();
    }

    public void SetTargetLayer()
    {
        grabComp.interactionLayers = targetLayer;
    }
}
