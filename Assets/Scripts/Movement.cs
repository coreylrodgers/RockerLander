using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audio;

    AudioSource audio;

    [SerializeField]
    float mainThrust = 100;

    [SerializeField]
    float rotatationThrust = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = gameObject.GetComponent<AudioSource>();
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
            PlaySFX();
        }
        else
        {
            StopSFX();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation (rotatationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotatationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        //freeze rotation so we can manually rotate
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);

        //unfreeze to allow physics to kick back in
        rb.freezeRotation = false;
    }

    void PlaySFX()
    {
        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }

    void StopSFX()
    {
        if (audio.isPlaying)
        {
            audio.Stop();
        }
    }
}
