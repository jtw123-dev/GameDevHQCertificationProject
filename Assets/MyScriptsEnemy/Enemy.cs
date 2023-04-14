using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using GameDevHQ.FileBase.Gatling_Gun;
public abstract class Enemy:MonoBehaviour 
{
    [SerializeField]protected float _health;//changed from int to float
    [SerializeField] protected float _speed;
    [SerializeField] protected int _creditsAwardedOnDeath;
    [SerializeField] protected Animator _anim;
    [SerializeField] protected GameObject _enemy;
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] protected Transform[] _waypoints;
    [SerializeField] protected bool _isDead;
    [SerializeField] protected AudioClip _fireSound;
    [SerializeField] protected GameObject _leftMuzzleFlash,_rightMuzzleFlash;
    protected AudioSource _audioSource;
    protected bool _startWeaponNoise;
    protected float _dissolving;
    protected bool _isAttacking;
    protected float _currentHealthOfTower;
    [SerializeField] protected float _attackDamage;
    [SerializeField] protected float _hideTimer;
    [SerializeField] protected int _livesToTake;

    public void Hide()
    {
        _agent.enabled = false;
        this.gameObject.SetActive(false);       
    }

    public virtual void Dead()
    {
        if (_health <= 0&&_isDead==false)//best to check bool up here rather than down there.
        {
            _isDead = true;               
            {            
                if(_audioSource!=null)
                {
                    _audioSource.Stop();
                }
                   
                _anim.applyRootMotion = false;

                if (_leftMuzzleFlash!=null)
                {
                    _leftMuzzleFlash.SetActive(false);
                }
             if (_rightMuzzleFlash!=null)
                {
                    _rightMuzzleFlash.SetActive(false);
                }
                _agent.enabled = false;
                UIManager.Instance.UpdateWarFunds(_creditsAwardedOnDeath);
                Invoke("Hide", _hideTimer);  
            }
        }      
    }
    public void OnStartUp()
    {
        transform.position = _waypoints[0].transform.position;
        _agent.enabled = true;
        _agent.speed = _speed;
        _agent.destination = _waypoints[1].transform.position;
        _isDead = false;
        if (_leftMuzzleFlash != null)
        {
            _leftMuzzleFlash.SetActive(false);
        }
        if (_rightMuzzleFlash != null)
        {
            _rightMuzzleFlash.SetActive(false);
        }
        if (_audioSource != null)
        {
            _audioSource.playOnAwake = false;
            _audioSource.loop = true;
            _audioSource.clip = _fireSound;
        }

        if (_anim != null)
        {
            _anim.applyRootMotion = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "End")
        {
            UIManager.Instance.UpdateLives(_livesToTake);
            Hide();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_leftMuzzleFlash != null)
        {
            _leftMuzzleFlash.SetActive(false);
        }
        if (_rightMuzzleFlash != null)
        {
            _rightMuzzleFlash.SetActive(false);
        }
        if (_audioSource != null)
        {
            _audioSource.Stop();
        }
        _startWeaponNoise = true;
    }
}
