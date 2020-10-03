using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.onCollidedWithPlayer += OnGameOver;
    }

    private void OnGameOver()
    {
        //Time.timeScale = 0;
    }

    private void OnDisable()
    {
        EventManager.onCollidedWithPlayer -= OnGameOver;
    }
}
