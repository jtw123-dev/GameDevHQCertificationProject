using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverEnemy : Enemy,IDamagable
{
    public float health { get; set; }

    public void Damage(float healthDamage)
    {
        throw new System.NotImplementedException();
    }

    private void OnEnable()
    {
        health = _health;
        transform.position = _waypoints[0].transform.position;
        _agent.enabled = true;
        _agent.speed = _speed;
        _agent.destination = _waypoints[1].transform.position;
        _isDead = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _agent.updateRotation = false;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(_agent.velocity.normalized);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Dead()
    {
        if (_health <= 0 && _isDead == false)//best to check bool up here rather than down there.
        {
            _isDead = true;
            {
                _agent.enabled = false;
                UIManager.Instance.UpdateWarFunds(300);
                Invoke("Hide", 0.5f);
            }
        }
    }
}
