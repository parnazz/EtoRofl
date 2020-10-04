using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesOnJump : MonoBehaviour
{
    private ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EventInitCoroutine());
    }

    private void SpawnParticles()
    {
        particleSystem.Play();
    }

    /// <summary>
    /// Уловка, чтобы партиклы не проигрывались с начала уровня
    /// </summary>
    /// <returns></returns>
    IEnumerator EventInitCoroutine()
    {
        yield return new WaitForSeconds(1);
        EventManager.onGrounded += SpawnParticles;
    }

    private void OnDisable()
    {
        EventManager.onGrounded -= SpawnParticles;
    }
}
