using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform _posTp;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _player;

    [Header("Rotacion")]
    [SerializeField] private float _rotSense;
    [SerializeField] private float _rotMin, _rotMax;
    private float _mouseX, _mouseY;


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        Cam();
        transform.position = _posTp.position;
        transform.LookAt(_player);

    }
    /// <summary>
    /// Rotacion de la camara en personaje con limite en eje Y.
    /// </summary>
    public void Cam()
    {
        _mouseX += _rotSense * Input.GetAxis("Mouse X");
        _mouseY -= _rotSense * Input.GetAxis("Mouse Y");
        _mouseY = Mathf.Clamp(_mouseY, _rotMin, _rotMax);


        _target.rotation = Quaternion.Euler(_mouseY, _mouseX, 0.0f);
        _player.rotation = Quaternion.Euler(0.0f, _mouseX, 0.0f);

    }
}
