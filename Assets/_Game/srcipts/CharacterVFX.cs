using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem _jumpEffect;

    public void Jump(Vector3 position)
    {
        _jumpEffect.transform.position = position;
        _jumpEffect.Play();
    }
}
