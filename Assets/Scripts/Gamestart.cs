using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamestart : MonoBehaviour
{
    
    public GameObject fireworkOrigin;
    public AudioClip MountainMusic;
    public AudioSource audioSource;
    private GameObject player;
    private MountainTopBehavior mountainTopBehavior;
    //private FadeAudioSource fade;
    private float duration = 8.0f;
    private float volumeMute = 0.0f;
    private float volumeLoud = 0.8f;
    private float volumeMiddle = 0.4f;
    private float randomRepeatTime;
    private float randomRange = 6.0f;
    private bool playerIsUp = false;

    // Fireworks
    public GameObject fireworks;
    public float rangeX = 8; // Dies ist der Bereich für X-Achse
    public float rangeY = 2; // Dies ist der Bereich für Y-Achse
    public float rangeZ = 8; // Dies ist der Bereich für Z-Achse

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        mountainTopBehavior = GameObject.FindObjectOfType<MountainTopBehavior>();
        audioSource.clip = MountainMusic;
        randomRepeatTime = Random.Range(3, 8);
        randomRange = Random.Range(-randomRange,randomRange);
        
    }

    // Depending on how far up the player is turn on sound and start firework at the end
    void Update()
    {
        if (player.transform.position.y > 10.0 && !playerIsUp)
        {
            if (!audioSource.isPlaying)
            {                
                audioSource.volume = volumeMute;
                audioSource.Play();
                StartCoroutine(FadeAudioSource.StartFade(audioSource, duration, volumeMiddle));
                Debug.Log("Audiosource is playing: " + audioSource.isPlaying);
            }
        }

        if (player.transform.position.y > 17.5  && !playerIsUp)
        {
            StartCoroutine(FadeAudioSource.StartFade(audioSource, duration, volumeLoud));
            StartCoroutine(SpawnFireworks());
            playerIsUp = true;
            mountainTopBehavior.ShowFinalCanvas();
        }

        if (playerIsUp)
        {
            DestroyFireworks();
        }
        
    }

    IEnumerator SpawnFireworks()
    {
       while (true)
       {
            Vector3 fireworksPosition = new Vector3(
                fireworkOrigin.transform.position.x + Random.Range(-rangeX, rangeX),
                fireworkOrigin.transform.position.y + Random.Range(-rangeY, rangeY),
                fireworkOrigin.transform.position.z + Random.Range(-rangeZ, rangeZ)
            );

            Debug.Log("Firework is here: " + fireworksPosition);
            Instantiate(fireworks, fireworksPosition, Quaternion.identity);

            yield return new WaitForSeconds(5);
       }
    }

    // Destroy firework after some time
    private void DestroyFireworks()
    {
        GameObject[] objectToDestroy = GameObject.FindGameObjectsWithTag("Firework");

        if(objectToDestroy.Length > 0)
        {
       
            foreach (GameObject obj in objectToDestroy)
            {
                Destroy(obj, 6.0f);
                Debug.Log("fireworks destroyed");
            }
        }
    }
}
