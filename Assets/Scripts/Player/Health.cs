using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    [Header("Vida")]
    [SerializeField] private float _life;
    [SerializeField] private float _maxLife;

    [Header("Vaiables de Nodaño")]
    [SerializeField] private bool _pause;
    [SerializeField] private int _wait;
    [SerializeField] private float _timeStop;

    [Header("Sonidos")]
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioClip _audioDmg;

    private void Start()
    {
        _life = _maxLife;
    }

    private void Update()
    {
        if (_life <= 0)
        {
            SceneManager.LoadScene(1);
        } 
    }
    public void PlayerDmg(float dmg)
    {
       if(!_pause && _life > 0)
        {
            audioManager.PlaySound(_audioDmg);
            _life -= dmg;
            StartCoroutine(Invensible());
            StartCoroutine(Stop());
            
        }
        
        
    }
    
    IEnumerator Invensible()
    {
        _pause = true;
        yield return new WaitForSeconds(_wait);
        _pause = false;

    }
    IEnumerator Stop()
    {
        var speed = GetComponent<PlayerMov>().movSpeed;
        GetComponent<PlayerMov>().movSpeed = 3;
        yield return new WaitForSeconds(_timeStop);
        GetComponent<PlayerMov>().movSpeed = speed;;

    }
}
