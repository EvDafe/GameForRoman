using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Turn : MonoBehaviour
{
    [SerializeField] private Turn _nextTurnPrefab;

    public UnityEvent OnEnd;
    public UnityEvent<string> OnStart;
    public UnityEvent onStart;

    private void Start()
    {
        List<ChessmanLevelUpper> levelUppers = FindObjectsByType<ChessmanLevelUpper>(0).ToList();
        SubscriptionLevelUppers(levelUppers);
        onStart?.Invoke();
    }
    private void SubscriptionLevelUppers(List<ChessmanLevelUpper> levelUppers)
    {
        levelUppers.ForEach(x => OnEnd.AddListener(x.RemoveKiller));
        levelUppers.ForEach(x => onStart.AddListener(x.RemoveKiller));
    }
    protected void EndTurn()
    {
        Instantiate(_nextTurnPrefab);
        OnEnd?.Invoke();
        Destroy(gameObject);
    }
}
