using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  
    [SerializeField] private PlayerMov _player;
    public delegate void Respawn();

    public event Respawn Recoloca; 


    

  public void muertePJ()
    {
        
        Recoloca?.Invoke();
    }

   
}
