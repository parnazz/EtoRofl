using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.onDoorClose += CloseDoor;
    }

    private void CloseDoor(int objectID)
    {
        if (objectID == gameObject.GetInstanceID())
        {
            animator.SetTrigger("Close");
            if (clip != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }

    private void OnDisable()
    {
        EventManager.onDoorClose -= CloseDoor;
    }
}
