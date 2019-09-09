using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    // Start is called before the first frame update

    Transform _target;
    NavMeshAgent _agent;

    [SerializeField] GameObject _preBullet;
    [SerializeField] Transform _pShoot;

    Transform _transform;
    bool _isShoot = true;
    IEnumerator DelayShoot () {
        _isShoot = false;
        createBullet ();
        yield return new WaitForSeconds (1);
        //reset shoot again
        _isShoot = true;
    }

    private void Awake () {
        GameManger.CountEnemy++;
    }
    void Start () {
        _transform = transform;
        _agent = GetComponent<NavMeshAgent> ();
        _agent.destination = Vector3.zero;
    }

    // Update is called once per frame
    void Update () {
        if (GameManger.isGameOver) {
            if (_agent) {
                _agent.speed = 0;
            }

            return;
        }

        if (_agent && _target) {
            _agent.destination = _target.position;

            float distance = Vector3.Distance (_transform.position, _target.position);
            if (distance <= 5 && _isShoot) {
                StartCoroutine (DelayShoot ());
            }
        }
    }

    public void SetTarget (Transform target) {
        _target = target;
    }

    void createBullet () {
        SoundManger.Instance.playSoundFire ();
        GameObject obj = Instantiate (_preBullet, _pShoot.position, transform.rotation);
        Bullet bullet = obj.GetComponent<Bullet> ();
        bullet.setTypeBullet (Bullet.BulletType.enemy);
    }

}