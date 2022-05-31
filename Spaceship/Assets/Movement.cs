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
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
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
        else
        {
        
            mainJet.Stop();
        }
        }
    }

    void ProcessRotation()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
            leftThrust.Play();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
            rightThrust.Play();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {

        rb.freezeRotation = true; // freeze rot to manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
