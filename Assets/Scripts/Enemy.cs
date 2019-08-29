using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    // Start is called before the first frame update
    
    [SerializeField] Transform _target;
    NavMeshAgent _agent;

    void Start () {
        _agent = GetComponent<NavMeshAgent> ();
        _agent.destination = _target.position;
    }

    // Update is called once per frame
    void Update () {
        if (_agent) {
            _agent.destination = _target.position;
        }
    }
}