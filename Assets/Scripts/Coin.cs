using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    private ScoreController _scoreController;

    public void Init(ScoreController scoreController)
    {
        _scoreController = scoreController;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController playerController))
        {
            _scoreController.AddPoint();
            Destroy(gameObject);
        }
    }
}
