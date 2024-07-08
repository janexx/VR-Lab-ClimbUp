using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GravityCannonRayInteractor : XRRayInteractor
{
    [Header("GravityCannonRayInteractor Canon")]
    private bool gravityButtonIsPressed;
    private bool gravityButtonIsReleased;
    public InteractionLayerMask teleportlayer;
    public InteractionLayerMask grabbablelayer;

    public ActionBasedController controller;
    public GameObject canonreticle;
    public GameObject teleportreticle;
    public XRInteractorLineVisual interactorline;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        interactionLayers = teleportlayer;
    }

    public void TurnOnGravityCanon()
    {
        Debug.Log("Gravity canon ON");
        // When A/X button is pressed (gravity canon is active) then set line to linear and show target cross reticle
        lineType = LineType.StraightLine;  // straight line
        //interactorline.reticle = canonreticle;
        ChangeReticle(canonreticle);
        interactionLayers = grabbablelayer;
        
    }

    public void TurnOffGravityCanon()
    {
        Debug.Log("Gravity canon OFF");
        lineType = LineType.ProjectileCurve;  // curved line
        interactionLayers = teleportlayer;
        ChangeReticle(teleportreticle);

        //interactorline.reticle.SetActive(false);
        //Destroy(canonreticle);
    }

    public void ChangeReticle(GameObject newReticele)
    {
        if (interactorline == null)
        {
            Debug.LogError("XRInteractorLineVisual is not assigned!");
            return;
        }

        if (newReticele == null)
        {
            Debug.LogError("New Reticle Prefab is not assigned!");
            return;
        }

         if(interactorline.reticle != null)
        {
            // Entferne das alte Reticle
            Destroy(interactorline.reticle.gameObject);
        }
        

        // Instanziere das neue Reticle
        GameObject newReticle = Instantiate(newReticele, interactorline.transform);

        // Setze das neue Reticle in der XRInteractorLineVisual Komponente
        interactorline.reticle = newReticle;
    }



}
