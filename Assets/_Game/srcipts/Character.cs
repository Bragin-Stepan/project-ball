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

    private Rigidbody _rigidbody;
    private CharacterVFX _vfx;
    private CoinCollector _coinCollector;
    private GroundDetector _groundDetector;
    private Movement _movement;

    private float _xInput;
    private float _zInput;
    private bool _canJump;

    private const string HorizontalNameInput = "Horizontal";
    private const string VerticalNameInput = "Vertical";
    private const string JumpNameInput = "Jump";

    private void Awake()
    {
        _groundDetector = GetComponentInChildren<GroundDetector>();
        _coinCollector = GetComponentInChildren<CoinCollector>();
        _vfx = GetComponentInChildren<CharacterVFX>();
        _rigidbody = GetComponent<Rigidbody>();

        _movement = new Movement(_rigidbody, _vfx);

        Wallet = new Wallet();
    }

    private void Start()
    {
        _coinCollector.Initialize(Wallet);
    }

    private void Update()
    {
        _xInput = Input.GetAxisRaw(HorizontalNameInput);
        _zInput = Input.GetAxisRaw(VerticalNameInput);

        if (Input.GetButtonDown(JumpNameInput) && _groundDetector.IsGrounded && _movement.IsFreezed == false)
            _canJump = true;
    }

    private void FixedUpdate()
    {
        TryMove();
        TryJump();
    }

    private void TryMove()
    {
        if (_movement.IsFreezed == false)
        {
            float speed = _groundDetector.IsGrounded ? _speed : _speed * _airSpeedMultiplier;
            _movement.Move(speed, _xInput, _zInput);
        }
    }

    private void TryJump()
    {
        if (_canJump)
        {
            _movement.Jump(_jumpForce);
            _canJump = false;
        }
    }

    public void Teleport(Vector3 position) => transform.position = position;

    public void Freeze() => _movement.Freeze();

    public void Unfreeze() => _movement.Unfreeze();
}