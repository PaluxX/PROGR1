using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMov : MonoBehaviour
{
    [Header("Animations")]
    [SerializeField] private string _xName = "xAxis";
    [SerializeField] private string _atkName = "onAttack";
    [SerializeField] private string _isMovName = "isMoving";
    [SerializeField] private string _zName = "zAxis";

    [Header("Movement")]
    [SerializeField] private float _movSpeed = 3f;

    [Header("Inputs")]
    [SerializeField] private KeyCode _atkKey = KeyCode.Mouse0;

    [Header("Ataque")]
    [SerializeField] private int _atackDmg = 51;
    [SerializeField] private Transform _atckOrigin;
    [SerializeField] private float _atckRayDistance = 3f;
    [SerializeField] private LayerMask _atckLayer;


    private float _xAxis = 0f, _zAxis = 0f;
    private Vector3 _dir = new();

    private Animator _anim;
    private Rigidbody _rb;


    private Ray _atckRay;
    private RaycastHit _atckHit;

    private void Awake()
    {
        //GameManager.Instance.Player = this;
        _rb= GetComponent<Rigidbody>();
        _rb.constraints= RigidbodyConstraints.FreezeRotation;

       
    }

    private void Start()
    {
       

        _anim=GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _xAxis = Input.GetAxis("Horizontal");
        _zAxis = Input.GetAxis("Vertical");
       
        _anim.SetFloat(_xName, _xAxis);
        _anim.SetFloat(_zName, _zAxis);

        _anim.SetBool(_isMovName, _xAxis != 0 || _zAxis != 0);

        if (Input.GetKeyDown(_atkKey))
        {
            _anim.SetTrigger(_atkName);
        }

    }

    private void FixedUpdate()
    {
        if (_xAxis != 0 || _zAxis != 0)
        {
            Movement(_xAxis, _zAxis);
        }
    }

    private void Movement(float xAxis, float zAxis)
    {
        _dir = (transform.right * xAxis + transform.forward * zAxis).normalized;

       _rb.MovePosition(transform.position+_dir*_movSpeed*Time.deltaTime);
    }

    public void Attack() 
    {
        _atckRay = new Ray(_atckOrigin.position, transform.forward);

        if (Physics.Raycast(_atckRay, out _atckHit, _atckRayDistance, _atckLayer))
        {
            if (_atckHit.collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDmg(_atackDmg);
            }
        }
    }
}
