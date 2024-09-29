using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private float _minRange = 4;
    private Rigidbody2D rb; 
    [SerializeField]
    private GameObject _player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
    
    void Update()
    {
        if(_player != null && Vector3.Distance(transform.position, _player.transform.position) > _minRange)
        { 
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
        }
    }
}
