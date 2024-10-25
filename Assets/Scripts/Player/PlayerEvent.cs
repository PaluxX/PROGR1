using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour
{
    private PlayerMov _parent;

    private void Start()
    {
        _parent= GetComponentInParent<PlayerMov>();
    }

    public void Attack()
    {
        _parent.Attack();
    }
}
