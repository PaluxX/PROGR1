using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    [SerializeField] private Butoon _boton;

    private Vector3 _posIni, _posFin;
    [SerializeField] private float _speed;

    [SerializeField] GameController _controller;

    private void Start()
    {
        _posIni = transform.position;
        _posFin = new Vector3(transform.position.x, -2.001f, transform.position.z);

        _boton.BotonPulsa += Abre;
        _controller.Recoloca += Reinicia;

    }

    void Abre()
    {
        StartCoroutine(BajaPuerta());
    }

    void Reinicia()
    {
        _posIni = transform.position;
    }

    private void OnDisable()
    {
        _boton.BotonPulsa -= Abre;
    }

    IEnumerator BajaPuerta()
    {
        while (transform.position.y > _posFin.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, _posFin, _speed * Time.deltaTime);
            yield return null;
        }
        transform.position = _posFin;
    }
}
