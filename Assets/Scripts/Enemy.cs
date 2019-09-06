using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    // Start is called before the first frame update

    Transform _target;
    NavMeshAgent _agent;

    private void Awake () {
        GameManger.CountEnemy++;
    }
    void Start () {
        _agent = GetComponent<NavMeshAgent> ();
        _agent.destination = Vector3.zero;
    }

    // Update is called once per frame
    void Update () {
        if (_agent && _target) {
            _agent.destination = _target.position;
        }
    }

    public void SetTarget (Transform target) {
        _target = target;
    }
}