using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabAndTeleport : MonoBehaviour
{
    private XRGrabInteractable grabComp;  // XR Grab Interactable component
    private TeleportationAnchor teleportComp; // Teleportation Area component
    private XRBaseInteractable interactable;

    private Rigidbody rb;
    private GameObject closestSocket;
    private bool isSnapped = false;
    private bool audioCreated = false;

    [Tooltip("The audio that is played when object snaps to socket")]
    public GameObject audioSource;

    [Tooltip("The threshold of the distance between object and socket for snapping")]
    public float snapThreshold = 0.1f;

    [Tooltip("The layer that's switched to after snapping")]
    public InteractionLayerMask targetLayer = 0;

    void Start()
    {
        grabComp = GetComponent<XRGrabInteractable>();
        teleportComp = GetComponentInChildren<TeleportationAnchor>();
        interactable = GetComponent<XRBaseInteractable>();
        teleportComp.enabled = false;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    void Update()
    {
        //FindClosestSocket();

        if (isSnapped && !audioCreated)
        {
            Instantiate(audioSource, transform.position, Quaternion.identity);
            audioCreated = true;
            Debug.Log("Audio created: " + audioCreated);
        }
    }

    //OnTriggerEnter prüft, ob der Stone nah genug ist, um zu "snappen". OnTriggerExit setzt den Stone zurück
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Socket"))
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            if (distance <= snapThreshold)
            {
                SnapToSocket(other.gameObject);
                Debug.Log("Snapped to socket.");
                // Deaktiviere die Interaktionsfähigkeit des Objekts
                //interactable.enabled = false;
                teleportComp.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == closestSocket)
        {
            isSnapped = false;
            grabComp.enabled = false; // was true
            rb.isKinematic = false;
            teleportComp.enabled = true;
            closestSocket = null;
            Debug.Log("Stone unsnapped from socket.");
        }
    }

    private void SnapToSocket(GameObject socket)
    {
        closestSocket = socket;
        transform.position = closestSocket.transform.position;
        transform.rotation = closestSocket.transform.rotation;

        isSnapped = true;
        grabComp.enabled = false;
        rb.isKinematic = true;
        teleportComp.interactionLayers = targetLayer;

        Debug.Log("Stone snapped to socket: " + closestSocket.name);
    }

    // Optional: If you need to find the closest socket from multiple sockets
    // Diese Methode durchläuft alle Sockets und findet den nächsten basierend auf der Distanz.
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