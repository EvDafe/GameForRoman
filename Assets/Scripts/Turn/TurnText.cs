using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TurnText : MonoBehaviour
{
    private Text _text;

    public static TurnText Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = GetComponent<TurnText>();
        else
            throw new InvalidOperationException();

        _text = GetComponent<Text>();
    }

    public void UpdateText(string Text)
    {
        _text.text = Text;
    }
}
