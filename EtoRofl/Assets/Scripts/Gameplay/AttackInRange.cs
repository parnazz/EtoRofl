using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInRange : MonoBehaviour
{
    [SerializeField] private float radius = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EventInitCoroutine());
    }

    IEnumerator EventInitCoroutine()
    {
        yield return new WaitForSeconds(1);
        EventManager.onGrounded += Attack;
    }

    private void Attack()
    {
        Vector3 center = transform.position;

        Collider[] colliders = Physics.OverlapSphere(center, radius);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Destroy(collider.gameObject);
            }
        }
    }
}
