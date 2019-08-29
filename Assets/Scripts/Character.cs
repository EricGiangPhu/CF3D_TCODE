using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    protected Transform _transform;
    protected Animator _ani;
    protected Rigidbody _rig;

    public float speed;
    public float speedAngle;

    public float speedJump;

    // Start is called before the first frame update

    private void Awake () {
        _ani = GetComponent<Animator> ();
        _rig = GetComponent<Rigidbody> ();
        _transform = this.transform;
    }

    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public virtual void Idle() {
        
    }

    public virtual void MoveUForward () {

    }

    public virtual void MoveBack () {

    }

    public virtual void RotationLeft () {

    }

    public virtual void RotaionRight () {

    }

    public virtual void Jump () {

    }

    public virtual void Fire () {

    }

}