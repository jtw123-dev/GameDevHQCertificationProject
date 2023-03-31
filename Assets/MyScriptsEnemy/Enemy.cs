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
    protected Tower _towerReference;
    protected bool _canDamage;
    protected Gatling_Gun _gatlingGun;
    protected bool _isAttacking;
    protected float _currentHealthOfTower;
    [SerializeField] protected float _attackDamage;

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
                _audioSource.Stop();             
                _anim.applyRootMotion = false;
                _leftMuzzleFlash.SetActive(false);
                _rightMuzzleFlash.SetActive(false);
                StartCoroutine(DissolveRoutine());
                _agent.enabled = false;
                _anim.SetTrigger("Death");
                UIManager.Instance.UpdateWarFunds(150);
                Invoke("Hide", 2.5f);  
            }
        }      
    }

    public virtual  IEnumerator DissolveRoutine()
    {
        return null;
    }

    public virtual IEnumerator ResetDissolve()
    {
        return null;
    }
   
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="End")
        {
            UIManager.Instance.UpdateLives();
            Hide();
        }
    }

  
}
