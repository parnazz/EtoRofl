﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static Action<int, GameObject> onDoorOpen;
    public static Action<int> onDoorClose;
    public static Action<int, Transform> onEnemyAgro;
    public static Action onCollidedWithPlayer;

    public static void CallOnDoorOpen(int objectID, GameObject nextTrigger)
    {
        onDoorOpen?.Invoke(objectID, nextTrigger);
    }

    public static void CallOnDoorClose(int objectID)
    {
        onDoorClose?.Invoke(objectID);
    }

    public static void CallOnEnemyAgro(int objectID, Transform player)
    {
        onEnemyAgro?.Invoke(objectID, player);
    }

    public static void CallOnCollidedWithPlayer()
    {
        onCollidedWithPlayer?.Invoke();
    }
}
