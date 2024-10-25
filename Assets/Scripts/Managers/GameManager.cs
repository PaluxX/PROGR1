using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private PlayerMov _player;
    
    public PlayerMov Player
    {
        get { return _player; }
        set { _player = value; }
    }

    private List<Enemy> _enemies = new();

    public List<Enemy> Enemies 
    { 
        get { return _enemies; } 
        set { _enemies = value; }
    }
}
