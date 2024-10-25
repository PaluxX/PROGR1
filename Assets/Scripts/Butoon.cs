using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butoon : MonoBehaviour
{
    public delegate void Pulsa();
    public event Pulsa BotonPulsa;

    private Vector3 _posIni, _posFin;

    [SerializeField] private GameController gameController;
    [SerializeField] private float _speed;


    void Start()
    {
        gameController.Recoloca += Reinicia;
        _posIni = transform.position;
        _posFin = new Vector3(3.5f, transform.position.y, transform.position.z);
    }

    private void Reinicia()
    {
        transform.position = _posIni;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (BotonPulsa != null)
            {
                BotonPulsa();
            }
            StartCoroutine(BotonPres());
        }
    }

    IEnumerator BotonPres()
    {
        while (transform.position.x > _posFin.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, _posFin, _speed * Time.deltaTime);
            yield return null;
        }
        transform.position = _posFin;
    }


}
