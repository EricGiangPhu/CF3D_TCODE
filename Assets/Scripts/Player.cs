using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public override void Idle () {
        Vector3 newVelocity = Vector3.zero;
        newVelocity.y = _rig.velocity.y;
        _rig.velocity = newVelocity;
        _rig.angularVelocity = Vector3.zero;
        _ani.SetBool ("run", false);
    }
    public override void MoveUForward () {
        Vector3 velocity = _rig.velocity;
        Vector3 moveForWard = _transform.forward * speed * Time.deltaTime;
        moveForWard.y = velocity.y;
        _rig.velocity = moveForWard;
        _ani.SetBool ("run", true);
    }

    public override void MoveBack () {
        Vector3 velocity = _rig.velocity;
        Vector3 moveForWard = -_transform.forward * speed * Time.deltaTime;
        moveForWard.y = velocity.y;
        _rig.velocity = moveForWard;
        _ani.SetBool ("run", true);
    }

    public override void RotationLeft () {
        _transform.Rotate (Vector3.up, -speedAngle * Time.deltaTime);
    }

    public override void RotaionRight () {
        _transform.Rotate (Vector3.up, speedAngle * Time.deltaTime);
    }

    public override void Jump () {
        _rig.AddForce (Vector3.up * speedJump * Time.deltaTime, ForceMode.Impulse);
    }

    public override void Fire () {
        _ani.SetTrigger ("shoot");
    }

}