using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private readonly float _moveSpeed = 3f;
    private readonly float _moveY = 20f;

    void Update()
    {
        transform.position += Vector3.down * _moveSpeed * Time.deltaTime;
        if (transform.position.y < -10)
        {
            transform.position += new Vector3(0, _moveY, 0);
        }
    }
}