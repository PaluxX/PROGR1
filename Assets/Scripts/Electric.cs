using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Electric : MonoBehaviour
{


    [SerializeField] private float _dmg;



    private void OnTriggerEnter(Collider col)
    {

        if (col.tag == "Player")
        {
            col.GetComponent<Health>().PlayerDmg(_dmg);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Health>().PlayerDmg(_dmg);
        }
    }

}
