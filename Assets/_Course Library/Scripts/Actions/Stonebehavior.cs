using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/* 
 * This script detects whether the object collides with the trigger and if so, 
 * the XRGrabInteractable script of the current object gets deactivated,
 * the desired interaction layer mask gets set,
 * the interaction layer of the socket where the object should get attached to, is set
 */

public class DeactivateGrab : MonoBehaviour
{
    private XRGrabInteractable grabComp;  // Component: Script XRGrabInteractable
    private TeleportationAnchor teleportComp; // Component: Teleportation Area

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
    private AudioSource stoneAudio;

    [Tooltip("The treshold of the distance between object and socket")]
    public float snapThreshold;    

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
        //rb.isKinematic = true;  //was false
        stoneAudio = GetComponentInChildren<AudioSource>();
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
            //Debug.Log("Stone" + this + "collides with Socket" + other.gameObject);


            if (Vector3.Distance(currentpos, currentSocketPos) <= snapThreshold && Vector3.Distance(currentpos, currentSocketPos) >= 0.05)
            {
                foreach (GameObject socket in allSockets)
                {
                    // Set stone to exact socket position and rotation
                    transform.position = currentSocketPos;
                    transform.rotation = closestSocket.transform.rotation;
                    //SetSnap(true);
                    isSnapped = true;
                    //Deactivate Grab script
                    grabComp.enabled = false;
                    //grabComp.interactionLayers = targetLayer;
                    // Activate Rigidbody
                    //rb.isKinematic = false; //was true
                    // Set target layer of teleportation anchor to the target layer
                    teleportComp.enabled = true;                    
                    Debug.Log("Stone is snapped: " + isSnapped);
                    //Debug.Log("Closest target socket " + closestSocket.name);
                }
                                  
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {        
        //Debug.Log("On Exit: Closest target socket " + closestSocket.name);
        teleportComp.enabled = true;
        //teleportComp.interactionLayers = targetLayer;
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
        //Debug.Log("Closest Socket: " + closest);
        return closest;        
    }

    // When colliding with any other surface play audio
    private void OnTriggerEnter(Collider other)
    {
        stoneAudio.Play();
    }
}
