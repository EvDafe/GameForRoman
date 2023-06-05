using System;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private uint _addedMoney;
    private float _money;

    public UnityEvent<float> OnChangeMoney;
    public static Wallet Instance { get; private set; } 
    public float Money => _money;

    private void Start()
    {
        if (Instance == null)
            Instance = GetComponent<Wallet>();
        else
            throw new InvalidOperationException();
    }
    public void TakeMoney()
    {
        _money += _addedMoney;
        OnChangeMoney?.Invoke(_money);
    }

    public void TryGiveMoney(float money)
    {
        if (money < 0) throw new ArgumentException();

        if(money <= _money)
        {
            _money -= money;
            OnChangeMoney?.Invoke(_money);
        }

    }
}
