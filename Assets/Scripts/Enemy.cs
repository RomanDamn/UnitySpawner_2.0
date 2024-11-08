using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Hero _targetHero;
    [SerializeField] private float _speed = 0.5f;

    private void Start()
    {
        transform.LookAt(_targetHero.transform.position);
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position , _targetHero.transform.position, _speed * Time.deltaTime);
    }
}
