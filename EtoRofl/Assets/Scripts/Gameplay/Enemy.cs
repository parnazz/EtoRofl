using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private Transform player;
    private bool bShouldRunToPlayer = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.onEnemyAgro += AgroOnPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent != null && player != null && bShouldRunToPlayer)
        {
            MoveToPlayer();
        }
    }

    private void AgroOnPlayer(int objectID, Transform playerTransform)
    {
        if (objectID == gameObject.GetInstanceID())
        {
            player = playerTransform;
            bShouldRunToPlayer = true;
        }
    }

    private void MoveToPlayer()
    {
        agent.destination = player.position;
        float inputMagnitude = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("InputMagnitude", inputMagnitude);
    }

    private void OnDisable()
    {
        EventManager.onEnemyAgro -= AgroOnPlayer;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.collider.CompareTag("Player"))
        {
            EventManager.CallOnCollidedWithPlayer();
        }
    }
}
