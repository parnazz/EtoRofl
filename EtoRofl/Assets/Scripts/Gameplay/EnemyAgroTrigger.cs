using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgroTrigger : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("Player") && enemy != null)
        {
            EventManager.CallOnEnemyAgro(enemy.gameObject.GetInstanceID(), other.transform);
            Destroy(this.gameObject);
        }
    }
}
