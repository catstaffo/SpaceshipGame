using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    // sin wave for game dev oscillating platform

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {  
        // if (period > 0f)
        // Mathf.Epsilon is standard w floats
        // bc it is the smallest float built into unity
        // it is unreliable to compare one float value == to another exact float value
        
        if(period > Mathf.Epsilon)
        {
            float cycles = Time.time / period; // continually growing over time
            const float tau = Mathf.PI * 2; // constant value of 6.283
            float rawSinWave = Mathf.Sin(cycles*tau); // from -1 to 1

            movementFactor = (rawSinWave + 1f)/2f; // recalculated to go from 0 to 1

            Vector3 offset = movementVector * movementFactor;
            transform.position = startingPosition + offset;
        }
        else
        {
            return;
        }

    }
}
