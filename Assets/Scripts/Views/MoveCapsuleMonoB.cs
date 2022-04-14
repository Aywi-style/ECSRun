using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCapsuleMonoB : MonoBehaviour
{
    private float _speed;
    private Transform _transform;

    void Start()
    {
        _speed = 2;
        _transform = transform;
    }

    void Update()
    {
        _transform.position += Vector3.forward * _speed * Time.deltaTime;
    }
}
