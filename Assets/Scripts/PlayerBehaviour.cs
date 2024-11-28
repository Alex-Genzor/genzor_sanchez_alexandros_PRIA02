using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;
    public float JumpVelocity = 5f; // <- funcion salto
    public float DistanceToGround = 0.1f; // <- fix salto
    public GameObject Bullet; // <- bullet shoot
    public float BulletSpeed = 100f; // <- bullet shoot

    public LayerMask GroundLayer; // <- fix salto

    private float _vInput;
    private float _hInput;
    private bool _isJumping; // <- funcion salto
    private CapsuleCollider _collider; // <- fix salto
    private bool _isShooting; // <- bullet shoot

    private Rigidbody _rigidBody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>(); // <- fix salto

    }

    // Update is called once per frame
    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        
        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);

        _isJumping |= Input.GetKeyDown(KeyCode.J); // <- 28/11/2024
        _isShooting |= Input.GetKeyDown(KeyCode.Space); // <- bullet shoot

    }
    
    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        
        _rigidBody.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);
        _rigidBody.MoveRotation(_rigidBody.rotation * angleRot);

        // funcion salto \/\/\/\/
        if (_isJumping && IsGrounded()) // <- IsGrounded() = fix salto
        {
            _rigidBody.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);

        }

        _isJumping = false;
        // funcion salto /\/\/\/\

        // funcion disparar \/\/\/\/
        if (_isShooting)
        {
            GameObject newBullet = Instantiate(Bullet, this.transform.position +
                new Vector3(0, 0, 1), this.transform.rotation);
            Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();

            BulletRB.velocity = this.transform.forward * BulletSpeed;

        }

        _isShooting = false;
        // funcion disparar /\/\/\/\

    }

    // fix salto \/\/\/\/
    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_collider.bounds.center.x,
            _collider.bounds.min.y, _collider.bounds.center.z);

        bool grounded = Physics.CheckCapsule(_collider.bounds.center,
            capsuleBottom, DistanceToGround, GroundLayer,
            QueryTriggerInteraction.Ignore);

        return grounded;

    }
    // fix salto /\/\/\/\

}
