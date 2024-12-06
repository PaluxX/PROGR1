using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> _inventory;
    [SerializeField] private Transform invContent;
    [SerializeField] private GameObject itemIconInv;

    private void Awake()
    {
        _inventory = new List<Item>();
    }

    public void AddToInv(Item inv)
    { 
      _inventory.Add(inv);
    }
}
