using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfTheGameTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            EventManager.CallOnWonTheGame();
            Destroy(this.gameObject);
        }
    }
}
