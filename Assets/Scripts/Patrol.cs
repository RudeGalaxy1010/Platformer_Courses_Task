using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _horizontalPatrolLimits;

    private Enemy _enemy;
    private Vector2 _destination;

    private void Start()
    {
        _enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        _destination = new Vector2(_horizontalPatrolLimits.x, _enemy.transform.position.y);
    }

    private void Update()
    {
        if ((Vector2)_enemy.transform.position != _destination)
        {
            _enemy.transform.position = Vector2.MoveTowards(_enemy.transform.position, _destination, Time.deltaTime * _speed);
        }
        else
        {
            SwitchDirection();
        }
    }

    private void SwitchDirection()
    {
        if (_destination.x == _horizontalPatrolLimits.x)
        {
            _destination = new Vector2(_horizontalPatrolLimits.y, _enemy.transform.position.y);
        }
        else
        {
            _destination = new Vector2(_horizontalPatrolLimits.x, _enemy.transform.position.y);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    float sizeX = (Mathf.Abs(_horizontalPatrolLimits.x) + _horizontalPatrolLimits.y) / 2f;
    //    Gizmos.DrawWireCube(transform.position, new Vector3(sizeX, 1, 0));
    //}
}
