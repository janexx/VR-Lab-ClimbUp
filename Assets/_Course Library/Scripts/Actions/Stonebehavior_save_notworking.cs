using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/* 
 * This script detects whether the object collides with the trigger and if so, 
 * the XRGrabInteractable script of the current object gets deactivated,
 * the desired interaction layer mask gets set,
 * the interaction layer of the socket where the object should get attached to, is set
 */

/*
public class DeactivateGrab : MonoBehaviour
{
    private XRGrabInteractable grabComp;  // Component: Script XRGrabInteractable
    private TeleportationAnchor teleportComp; // Component: Teleportation Area
    private SetInteractionLayer SetInteractionLayerScript;


    private Rigidbody rb;
    private Vector3 currentSocketPos;
    private Vector3 currentpos;
    private bool isSnapped = false;
    private bool audioCreated = false;

    [Tooltip("The socket that should get triggered")]
    private GameObject targetSocket;
    private GameObject closestSocket;
    

    [Tooltip("The audio that is played when object snaps to socket")]
    public GameObject audioSource;

    [Tooltip("The treshold of the distance between object and socket")]
    public float snapThreshold = 0.1f;    

    [Tooltip("The layer that's switched to")]
    public InteractionLayerMask targetLayer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        grabComp = GetComponent<XRGrabInteractable>();
        //socketcomp = targetSocket.GetComponent<XRSocketInteractor>();
        teleportComp = GetComponentInChildren<TeleportationAnchor>();
        teleportComp.enabled = false;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;  //was false
        isSnapped = false;
        audioCreated = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Instantiate Prefab with audio (play on awake) if stone is snapped to socket and the instance does not yet exist
        if (isSnapped && !audioCreated)
        {
            Instantiate(audioSource, currentpos, Quaternion.identity);
            audioSource.GetComponent<AudioSource>().Play();
            isSnapped = false;
            audioCreated = true;
            Debug.Log("Audio is created: " + audioCreated);
        }    
        
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Socket")
        {
            // Track Position of Stone 
            currentpos = transform.position;
            GameObject[] allSockets = GameObject.FindGameObjectsWithTag("Socket");
            closestSocket = FindClosestSocket();
            currentSocketPos = FindClosestSocket().transform.position;
            Debug.Log("OnTriggerEnter: Closest socket is " + closestSocket);

            if (Vector3.Distance(currentpos, currentSocketPos) <= snapThreshold && Vector3.Distance(currentpos, currentSocketPos) >= 0.1)
            {
                //foreach (GameObject socket in allSockets)
                //{
                    // Set stone to exact socket position and rotation
                    transform.position = currentSocketPos;
                    transform.rotation = closestSocket.transform.rotation;
                    //SetSnap(true);
                    isSnapped = true;
                    //Deactivate Grab script
                    grabComp.enabled = false;
                    Debug.Log("Grab is: " + grabComp.enabled);
                    
                    // Activate Rigidbody
                    rb.isKinematic = true; 
                    // Set target layer of teleportation anchor to the target layer
                    teleportComp.enabled = true;
                    teleportComp.interactionLayers = targetLayer;
                    Debug.Log("IsSnapped ist: " + isSnapped);
                    Debug.Log("Closest target socket " + closestSocket.name);

                    // Set original interaction layers so that distance grab is not possible
                    GameObject.Find("RightHand Ray").GetComponent<SetInteractionLayer>().SetOriginalLayer();
                    GameObject.Find("LeftHand Ray").GetComponent<SetInteractionLayer>().SetOriginalLayer();
                //}

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //FindClosestSocket();
        closestSocket = FindClosestSocket();
        Debug.Log("On Exit: Closest target socket " + closestSocket.name);
        teleportComp.enabled = false;
        //teleportComp.interactionLayers = targetLayer;
        //Activate Grab script
        grabComp.enabled = true;
        rb.isKinematic = false;

        // Set TargetLayer interaction layers so that distance grab is not possible
        GameObject.Find("RightHand Ray").GetComponent<SetInteractionLayer>().SetTargetLayer();
        GameObject.Find("LeftHand Ray").GetComponent<SetInteractionLayer>().SetTargetLayer();
    }

    private GameObject FindClosestSocket()
    {
        GameObject[] allSockets = GameObject.FindGameObjectsWithTag("Socket");
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject socket in allSockets)
        {
            float distance = Vector3.Distance(socket.transform.position, position);
            if (distance < minDistance)
            {
                closest = socket;
                minDistance = distance;
            }
        }

        return closest;
    }
}
*/
