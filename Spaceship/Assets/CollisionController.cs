using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    int currentSceneIndex;

    void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    } 

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Frend":
                Debug.Log("Chill");
                break;
            case "Finish":
                Debug.Log("Yo damn");
                StartLandingSequence();
                break;
            default:
                Debug.Log("Ya dun goofed");
                StartCrashSequence();;
                break;

        }
    }

    void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", loadDelay);
    }

    void StartLandingSequence()
    {
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
