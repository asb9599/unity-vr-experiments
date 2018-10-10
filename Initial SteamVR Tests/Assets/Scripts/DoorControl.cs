using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    // Public Variables
    public bool isOpen;
    // Private Variables
    Animator anim;
    AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        // Cache animator component
        anim = GetComponent<Animator>();
        // Cache audio source component
        audioSource = GetComponent<AudioSource>();
        // Set isOpen to be false
        isOpen = false;
    }

    public void Open()
    {
        // Check if isOpen is set to false
        if (isOpen == false)
        {
            // Set isOpen to true
            isOpen = true;
            // Play the door opening sound effect
            audioSource.Play();
            // Fire off the open trigger of the animator
            anim.SetTrigger("Open");
        }
    }

    public void Close()
    {

        // Check if isOpen is set to true
        if (isOpen == true)
        {
            // Set isOpen to false
            isOpen = false;
            // Fire off the close trigger of the animator
            anim.SetTrigger("Close");
        }
    }
}
