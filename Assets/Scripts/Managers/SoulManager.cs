using System;
using UnityEngine;

public class SoulManager : MonoBehaviour
{
    public static SoulManager Instance { get; private set; }

    // Variables
    public int SoulCount;
    [SerializeField] private int _maxSouls = 2;

    // Events
    public Action OnAllSoulCollected;

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
        OnAllSoulCollected?.Invoke();
    }
}
