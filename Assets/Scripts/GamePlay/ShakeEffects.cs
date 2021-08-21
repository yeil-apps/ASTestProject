using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeEffects : MonoBehaviour
{
    [SerializeField] private GameObject _objToShake;
    [SerializeField] private float _startBounceDuration = 1.5f;
    [SerializeField] private Vector3 _startStrength = new Vector3(0, 1.5f, 0);
    [SerializeField] private int _shakeRandomness = 1;

    [SerializeField] private float _clickShakeDuration = 0.7f;
    [SerializeField] private Vector3 _correctClickStrength = new Vector3(0, 0.3f, 0);
    [SerializeField] private Vector3 _wrongClickStrength = new Vector3(0.3f, 0, 0);

    public void StartBounceEffect()
    {
        if (FindObjectOfType<Spawner>().NeedBounceEffect == true)
            transform.DOShakePosition(_startBounceDuration, strength: _startStrength, vibrato: 5, randomness: _shakeRandomness);
    }

    public void CorrectClickShake()
    {
        _objToShake.transform.DOShakePosition(_clickShakeDuration, strength: _correctClickStrength, vibrato: 5, randomness: _shakeRandomness);
    }

    public void WrongClickShake()
    {
        _objToShake.transform.DOShakePosition(_clickShakeDuration, strength: _wrongClickStrength, vibrato: 10, randomness: _shakeRandomness);
    }
}
