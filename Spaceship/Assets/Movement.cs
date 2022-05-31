using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100;
    [SerializeField] float rotationSpeed = 100;

    Rigidbody rb;

    AudioSource audioSource;
    [SerializeField] AudioClip thrust;

    [SerializeField] ParticleSystem mainJet;
    [SerializeField] ParticleSystem leftThrust;
    [SerializeField] ParticleSystem rightThrust;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();

        // debug keys
        if(Input.GetKeyDown(KeyCode.C))
        {
            Physics.IgnoreLayerCollision(0,0);
        }
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            BeginThrust();
        }
        else
        {
            mainJet.Stop();
        }
    }

    void ProcessRotation()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
    }

    void BeginThrust()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(thrust);
        }
        if (!mainJet.isPlaying)
        {
            mainJet.Play();
        }
    }

    void RotateLeft()
    {
        ApplyRotation(rotationSpeed);
        leftThrust.Play();
    }

    void RotateRight()
    {
        ApplyRotation(-rotationSpeed);
        rightThrust.Play();
    }

    void ApplyRotation(float rotationThisFrame)
    {

        rb.freezeRotation = true; // freeze rot to manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }

    void DebugKeys()
    {
    if(Input.GetKeyDown("C"))
        {
            Physics.IgnoreLayerCollision(0,5);
        }
    }
}
