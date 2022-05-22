using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public int Points { get; private set; }

    private void Start()
    {
        Points = 0;
        _scoreText.text = Points.ToString();
    }

    public void AddPoint()
    {
        Points++;
        _scoreText.text = Points.ToString();
    }
}
