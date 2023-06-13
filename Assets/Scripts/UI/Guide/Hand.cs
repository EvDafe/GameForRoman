using System;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private static Hand _instance;

    private void Awake()
    {
        if (_instance == null)
            _instance = GetComponent<Hand>();
        else
            throw new InvalidOperationException();
    }
}
