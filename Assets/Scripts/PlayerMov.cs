using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMov : MonoBehaviour
{
    [SerializeField] private float _movSpeed = 3f;
    [SerializeField] private bool _canRot = true;
    [SerializeField] private float _rotSpeed = 120f;


    private float _xAxis = 0f, _zAxis = 0f;
    private Vector3 _dir = new();

    private Rigidbody _rb;

    private void Awake()
    {
        _rb= GetComponent<Rigidbody>();
        _rb.constraints= RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        if (_canRot)
        {
            _xAxis = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            _xAxis = Input.GetAxis("Horizontal");

        }
        _zAxis = Input.GetAxis("Vertical");


        if (_xAxis != 0 || _zAxis != 0)
        {
            Movement(_xAxis, _zAxis);
        }

    }

    private void Movement(float xAxis, float zAxis)
    {
        if (_canRot)
        {
            transform.position += (transform.forward * zAxis) * _movSpeed * Time.deltaTime;

            transform.Rotate(0f, xAxis * _rotSpeed * Time.deltaTime, 0f);
        }
        else
        {
            _dir = (transform.right * xAxis + transform.forward * zAxis).normalized;

            transform.position += _dir * _movSpeed * Time.deltaTime;
        }
    }
}
