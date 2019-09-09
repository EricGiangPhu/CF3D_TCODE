using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public enum BulletType {
        none,
        player,
        enemy
    }
    float _timeDestroy = 4;
    float speed = 500;

    BulletType _type = BulletType.none;

    Rigidbody _rigid;
    // Start is called before the first frame update

    GameManger _gameManager;
    void Start () {
        //
        _rigid = GetComponent<Rigidbody> ();
        GameObject gameObject = GameObject.Find ("GameMager");
        if (gameObject) {
            _gameManager = gameObject.GetComponent<GameManger> ();
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (_rigid) {
            Vector3 moveForward = transform.forward * speed * Time.deltaTime;
            _rigid.velocity = moveForward;
        }
    }

    public void SetTimeDestroy (float time) {
        _timeDestroy = time;
    }

    public void setTypeBullet (BulletType type) {
        _type = type;
    }

    public void DestroyBullet () {
        Destroy (gameObject);
    }

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("enemy") && _type == BulletType.player) {

            //destroy enemy
            Destroy (other.gameObject);

            //destroy bullet
            Destroy (gameObject);

            if (_gameManager) {
                _gameManager.IncreateScore ();
            }
        } else if (other.gameObject.CompareTag ("Player") && _type == BulletType.enemy) {
            //destroy bullet
            Destroy (gameObject);

            //end game
            _gameManager.ShowGameOver ();
        }
    }
}