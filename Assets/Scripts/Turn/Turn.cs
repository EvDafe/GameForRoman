using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Turn : MonoBehaviour
{
    [SerializeField] private Turn _nextTurnPrefab;

    private UnityEvent OnEnd;
    public UnityEvent<string> OnStart;

    private void Start()
    {
        List<ChessmanLevelUpper> levelUppers = FindObjectsByType<ChessmanLevelUpper>(0).ToList();
        SubscriptionLevelUppers(levelUppers);
    }
    private void SubscriptionLevelUppers(List<ChessmanLevelUpper> levelUppers)
    {
        levelUppers.ForEach(x => OnEnd.AddListener(x.RemoveKiller));
    }
    protected void EndTurn()
    {
        Instantiate(_nextTurnPrefab);
        OnEnd?.Invoke();
        Destroy(gameObject);
    }
}
