using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Character : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _airSpeedMultiplier;

    public Wallet Wallet { get; private set; }
    public bool IsGrounded { get; private set; }

    private Rigidbody _rigidbody;
    private Collider _collider;
    public CharacterVFX _vfx;

    private float _xInput;
    private float _zInput;
    private bool _jumpInput;

    private bool _isFreezed;

    private const string HorizontalNameInput = "Horizontal";
    private const string VerticalNameInput = "Vertical";
    private const string JumpNameInput = "Jump";

    private void Awake()
    {
        _vfx = GetComponentInChildren<CharacterVFX>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();

        Wallet = new Wallet();
    }

    private void Update()
    {
        _xInput = Input.GetAxisRaw(HorizontalNameInput);
        _zInput = Input.GetAxisRaw(VerticalNameInput);

        if (Input.GetButtonDown(JumpNameInput) && IsGrounded && _isFreezed == false)
            Jump();
    }

    private void FixedUpdate()
    {
        if (_isFreezed == false)
            Move();
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.GetComponent<Ground>())
            IsGrounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.GetComponent<Ground>())
            IsGrounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.gameObject.GetComponent<Coin>();

        if (coin)
            PickUpCoin(coin);
    }

    private void PickUpCoin(Coin coin)
    {
        Wallet.AddCoin(coin);
        coin.PickUp();
    }

    private void Move()
    {
        float speed = IsGrounded ? _speed : _speed * _airSpeedMultiplier;
        _rigidbody.AddForce(_xInput * speed, 0, _zInput * speed);
    }

    private void Jump()
    {
        _vfx.Jump(transform.position);
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    public void Teleport(Vector3 position) => transform.position = position;

    public void Freeze()
    {
        _isFreezed = true;
        _rigidbody.isKinematic = true;
    }

    public void Unfreeze()
    {
        _isFreezed = false;
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = Vector3.zero;
    }
}
