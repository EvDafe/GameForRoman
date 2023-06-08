using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Chessman—ontainer : MonoBehaviour
{
    [SerializeField] private List<EnemyChessman> _enemyChessmans;
    [SerializeField] private List<PlayerChessman> _playerChessmans;

    public List<EnemyChessman> EnemyChessmans => _enemyChessmans;
    public List<PlayerChessman> PlayerChessmans => _playerChessmans;
    public static Chessman—ontainer Instance { get; private set; }
    public UnityEvent OnRemoveChessman;

    private void Awake()
    {
        if (Instance == null)
            Instance = GetComponent<Chessman—ontainer>();
        else
            throw new InvalidOperationException();

        
    }
    public void RemovePlayer(PlayerChessman playerChessman)
    {
        _playerChessmans.Remove(playerChessman);
        OnRemoveChessman?.Invoke();
    }
    public void AddPlayer(PlayerChessman playerChessman)
    {
        _playerChessmans.Add(playerChessman);
    }
    public void RemoveEnemy(EnemyChessman enemyChessman)
    {
        _enemyChessmans.Remove(enemyChessman);
        OnRemoveChessman?.Invoke();
    }
    public void AddEnemy(EnemyChessman enemyChessman)
    {
        _enemyChessmans.Add(enemyChessman);
    }
}
