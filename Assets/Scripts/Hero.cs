using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private Vector3 _targetPostion;
    [SerializeField] private float _speed = 0.5f;

    private Vector3 _basePosition;

    private void Start()
    {
        _basePosition = transform.position;
        transform.LookAt(_targetPostion);
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        var distance = Vector3.Distance(_targetPostion, transform.position);
        var isPointReached = distance <= 0.1;
        var step = _speed * Time.deltaTime;

        if (isPointReached)
        {
            var tempTargetPosition = _targetPostion;
            _targetPostion = _basePosition;
            _basePosition = tempTargetPosition;
            transform.LookAt(_targetPostion);
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetPostion, step);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.gameObject.SetActive(false);
        }
    }
}
