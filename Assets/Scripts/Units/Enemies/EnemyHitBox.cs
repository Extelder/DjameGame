using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : HitBox
{
    [SerializeField] private Pool _bloodPool;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _hurtSounds;

    public override void Hit(Rapier rapier)
    {
        base.Hit(rapier);
        _bloodPool.GetFreeElement(rapier.Hit.point);
        Rapier.Instance.FleshSound();

        _audioSource.clip = _hurtSounds[Random.Range(0, _hurtSounds.Length)];
        _audioSource.Play();
    }
}