using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    int currentSceneIndex;

    AudioSource audioSource;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip failure;

    // ParticleSystem rocketParticleSystem;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    bool isTransitioning = false;

    void Awake()
    {
        
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    } 

    void OnCollisionEnter(Collision other)
    {
        if(!isTransitioning)
        {
            switch (other.gameObject.tag)
            {
                case "Frend":
                    Debug.Log("Chill");
                    break;
                case "Finish":
                    Debug.Log("Yo damn");
                    StartLandingSequence();
                    audioSource.PlayOneShot(success);
                    break;
                default:
                    Debug.Log("Ya dun goofed");
                    StartCrashSequence();
                    audioSource.PlayOneShot(failure);
                    break;

            }
        }
        else
        {
            return;
        }
    }

    void StartCrashSequence()
    {   crashParticles.Play();
        audioSource.Stop();
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", loadDelay);
    }

    void StartLandingSequence()
    {   successParticles.Play();
        audioSource.Stop();
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNewScene", loadDelay);
    }

    void LoadNewScene()
    {
        SceneManager.LoadScene(currentSceneIndex+1);
        Debug.Log("Load new scene!");
    }

    void ReloadScene()
    {
        
        SceneManager.LoadScene(currentSceneIndex);
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // rocketParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
