using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Door propertiese")]
    [SerializeField]
    private float doorOpenAngle;
    [SerializeField]
    private float doorClosedAngle;
    [SerializeField]
    private float smooth;
    private bool isLocked = true,isOpen = false;
    
    [Header("Audio settings")]
    [SerializeField]
    private AudioSource audio;
    
    [SerializeField]
    private AudioClip doorClosed,doorOpen;
    
    public void Open()
    {
        if(!isLocked)
        {
            if(!isOpen)
            {
                isOpen = true;
                audio.clip = doorOpen;
                audio.Play();
            }
        }
        else
        {
            audio.clip = doorClosed;
            audio.Play();
        }
    }

    public void Unlock()
    {
        isLocked = false;
    }

    private void Update ()
    {
        if (isOpen)
        {
            Quaternion targetRotationOpen = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotationClosed = Quaternion.Euler(0, doorClosedAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationClosed, smooth * Time.deltaTime);
        }
    }
}
