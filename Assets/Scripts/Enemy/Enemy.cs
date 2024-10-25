using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    [Header("AI")]

    [SerializeField] private float _distance = 6f;
    [SerializeField] private float _atckDistance = 3f;
    [SerializeField] private float _changeNodeDist = 2f;


    [Header("Stats")]
    [SerializeField] private int _maxHp = 100;
    private int _actualHp;

    private Transform _target, _actualNode;
    private List<Transform> _meshNodes = new();
    public List<Transform> NavMeshNodes 
    {
        get { return _meshNodes; }
        set { _meshNodes = value; }
    }
    
       


    private NavMeshAgent _agent;

    private void Awake()
    {
        _actualHp = _maxHp;
    }

    private void Start()
    {
        _agent= GetComponent<NavMeshAgent>();
        _target = GameManager.Instance.Player.transform;
        GameManager.Instance.Enemies.Add(this);
    }

    public void Initialize()
    {
        

        _actualNode = GetNode();

        _agent.SetDestination(_actualNode.position);
    }

    private void Update()
    {
        if(Vector3.SqrMagnitude(transform.position- _target.position) <= _distance* _distance) //si la dist entre pj y enemy es <= a dist de persecucuion
        {
            if (Vector3.SqrMagnitude(transform.position - _target.position) <= _atckDistance * _atckDistance ) //<= la distancia de ataque
            {
                if (!_agent.isStopped) _agent.isStopped = true; //ataca
                {

                    Debug.Log("Ataca");
                }
            }
            else
            {
                if (!_agent.isStopped) _agent.isStopped = false; //persigue
                _agent.SetDestination(_target.position);
            }

        }
        else
        {
            if (_agent.destination != _actualNode.position) _agent.SetDestination(_actualNode.position); //si es mayor a la distance de persecucucion, pregunta si es mismo nodo, si es asi vuelve al nodo

            if (Vector3.SqrMagnitude(transform.position - _actualNode.position) <= _changeNodeDist* _changeNodeDist) // si distancia entre nodo actual y pos de enemigo es <= cambia
              {
                _actualNode=GetNode(_actualNode);

                _agent.SetDestination(_actualNode.position);
              }
        }
    }

    private Transform GetNode(Transform lastNode = null)
    {
        Transform newNode = _meshNodes[Random.Range(0, _meshNodes.Count)];

        while (lastNode == newNode) 
        {
            newNode = _meshNodes[Random.Range(0,_meshNodes.Count)];
        }

        return newNode;
    }

    public void TakeDmg(int dmg)
    {
        _actualHp -= dmg;
        if (_actualHp <= 0)
        {
            Debug.Log("Murio");
            GameManager.Instance.Enemies.Remove(this);
            Destroy(gameObject);
        }
        else 
        {
            Debug.Log("Hice" + dmg + "queda" + _actualHp);
        }
    }
}
