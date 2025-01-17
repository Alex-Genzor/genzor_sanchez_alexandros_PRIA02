using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public GameObject bullet;
   
    public float bulletSpeed = 100f;

    public LayerMask groundLayer;

    private float _vInput;
    private float _hInput;
    private bool _isJumping;
    private CapsuleCollider _collider;
    private bool _isShooting;

    private Rigidbody _rigidBody;

    private GameBehaviour _gameManager; // herir jugador 1
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameBehaviour>(); // herir jugador 1

    }

    // Update is called once per frame
    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * moveSpeed;
        _hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        
        this.transform.Translate(Vector3.forward * (_vInput * Time.deltaTime));
        this.transform.Rotate(Vector3.up * (_hInput * Time.deltaTime));

        _isJumping |= Input.GetKeyDown(KeyCode.J); 
        _isShooting |= Input.GetKeyDown(KeyCode.Space); 

    }
    
    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        
        _rigidBody.MovePosition(this.transform.position + this.transform.forward * 
            (_vInput * Time.fixedDeltaTime));
        _rigidBody.MoveRotation(_rigidBody.rotation * angleRot);

        if (_isJumping && IsGrounded()) 
        {
            _rigidBody.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);

        }

        _isJumping = false;

        if (_isShooting)
        {
            GameObject newBullet = Instantiate(bullet, this.transform.position +
                new Vector3(0, 0, 1), this.transform.rotation);
            Rigidbody bulletRigidBody = newBullet.GetComponent<Rigidbody>();

            bulletRigidBody.velocity = this.transform.forward * bulletSpeed;

        }

        _isShooting = false;

    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_collider.bounds.center.x,
            _collider.bounds.min.y, _collider.bounds.center.z);

        bool grounded = Physics.CheckCapsule(_collider.bounds.center,
            capsuleBottom, distanceToGround, groundLayer,
            QueryTriggerInteraction.Ignore);

        return grounded;

    }

    // herir jugador 1 \/\/\/\/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            _gameManager.HP--;

        }    
        
    }
    
    // herir jugador 1 /\/\/\/\
    
}
