using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    float _timeDestroy = 4;
    float speed = 500;

    Rigidbody _rigid;
    // Start is called before the first frame update
    void Start () {
        //
        _rigid = GetComponent<Rigidbody> ();

        // Destroy (gameObject, _timeDestroy);
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

    public void DestroyBullet () {
        Destroy (gameObject);
    }

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag("enemy")) {

            //destroy enemy
            Destroy (other.gameObject);

            //destroy bullet
            Destroy (gameObject);
        }

        Debug.Log(other.gameObject.tag); 
    }
}