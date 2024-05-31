using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Spawn an object at a transform's position
/// </summary>
public class SpawnObject : MonoBehaviour
{
    [Tooltip("The object that will be spawned")]
    public GameObject originalObject = null;

    [Tooltip("The transform where the object is spanwed")]
    public Transform spawnPosition = null;

    public XRBaseInteractor spawnPointInteractor;

    private bool isSpawned =false;

    public void Spawn()
    {
        Instantiate(originalObject, spawnPosition.position, spawnPosition.rotation);
    }

    public void SpawnStone()
    {
        if (!isSpawned)
        {
            GameObject newStone = Instantiate(originalObject, spawnPointInteractor.transform.position, spawnPointInteractor.transform.rotation);
            XRBaseInteractable interactable = newStone.GetComponent<XRBaseInteractable>();
            spawnPointInteractor.StartManualInteraction(interactable as IXRSelectInteractable);
            isSpawned = true;
        }

    }

    private void OnValidate()
    {
        if (!spawnPosition)
            spawnPosition = transform;
    }
}
