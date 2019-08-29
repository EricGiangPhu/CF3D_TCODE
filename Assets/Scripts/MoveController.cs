using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {
    Player _player;
    // Start is called before the first frame update
    private void Awake () {
        _player = GetComponent<Player> ();
    }
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        // chuyen ve trang thai dung yen
        if (Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.S) ) {
            _player.Idle ();
        }

        if (Input.GetKey (KeyCode.W)) {
            _player.MoveUForward ();
        } else if (Input.GetKey (KeyCode.S)) {
            _player.MoveBack ();
        }

        if (Input.GetKey (KeyCode.D)) {
            _player.RotaionRight ();
        } else if (Input.GetKey (KeyCode.A)) {
            _player.RotationLeft ();
        }

        if (Input.GetKeyDown (KeyCode.Space)) {
            _player.Jump ();
        }

        if (Input.GetKeyDown (KeyCode.Return) || Input.GetMouseButtonDown (0)) {
            _player.Fire ();
        }
    }
}