using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy:MonoBehaviour 
{
    [SerializeField]protected int _health;
    [SerializeField] protected float _speed;
    [SerializeField] protected int _creditsAwardedOnDeath;
    [SerializeField] protected Animator _anim;
    [SerializeField] protected GameObject _enemy;
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] protected Transform[] _waypoints;
    [SerializeField] protected bool _isDead;

    public virtual void Die()
    {

    }

    public virtual void EnemyAttack()

    {

    }

    public virtual void Movement()
    {

    }

    public virtual void Dead()
    {

    }
}
