using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenTrigger : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject nextTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            EventManager.CallOnDoorOpen(door.GetInstanceID(), nextTrigger);
            Destroy(this.gameObject);
        }
    }
}
