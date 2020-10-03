using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
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
        EventManager.onDoorOpen += OpenDoor;
    }

    private void OpenDoor(int objectID, GameObject nextTrigger)
    {
        if (objectID == gameObject.GetInstanceID())
        {
            animator.SetTrigger("Open");

            if (clip != null)
            {
                audioSource.PlayOneShot(clip);

                if (nextTrigger != null)
                {
                    StartCoroutine(WaitEndOfClipCoroutine(nextTrigger));
                }
            }
        }
    }

    private IEnumerator WaitEndOfClipCoroutine(GameObject nextTrigger)
    {
        yield return new WaitForSeconds(clip.length);
        nextTrigger.SetActive(true);
    }

    private void OnDisable()
    {
        EventManager.onDoorOpen -= OpenDoor;
    }
}
