using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Sprite _itemMedKit;
    [SerializeField] private int _itemCount;



    public void Interact(Inventory player)
    { 
     player.AddToInv(this);
    }
}
