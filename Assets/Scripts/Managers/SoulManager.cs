using System;
using UnityEngine;

public class SoulManager : MonoBehaviour
{
    public static SoulManager Instance { get; private set; }

    // Variables
    public int SoulCount;
    private int _maxSouls;
    private bool _isAllSoulsCollected;

    // Events
    public Action<bool> OnAllSoulCollected;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (SoulCount == _maxSouls)
        {
            HandleAllSoulCollected();
        }
    }

    public void HandleAllSoulCollected()
    {
        _isAllSoulsCollected = true;

        OnAllSoulCollected?.Invoke(_isAllSoulsCollected);
    }
}
