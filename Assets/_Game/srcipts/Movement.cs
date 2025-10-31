using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    private Rigidbody _rigidbody;

    private CharacterVFX _vfx;

    public Movement(Rigidbody rigidbody, CharacterVFX vfx)
    {
        _rigidbody = rigidbody;
        _vfx = vfx;
    }

    public bool IsFreezed;

    public void Move(float speed, float xDirection, float zDirection)
    {
        if (IsFreezed == false)
            _rigidbody.AddForce(xDirection * speed, 0, zDirection * speed);
    }

    public void Jump(float jumpForce)
    {
        _vfx.Jump(_rigidbody.gameObject.transform.position);
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void Freeze()
    {
        IsFreezed = true;
        _rigidbody.isKinematic = true;
    }

    public void Unfreeze()
    {
        IsFreezed = false;
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = Vector3.zero;
    }
}