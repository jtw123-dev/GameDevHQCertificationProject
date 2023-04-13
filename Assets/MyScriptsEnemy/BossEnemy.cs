using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy :Enemy,IDamagable
{
    public float health { get; set; }
    [SerializeField] private GameObject _fireTornado;
    [SerializeField] private GameObject _rotateTurret;
    [SerializeField] private GameObject _explosion;

    public void Damage(float healthDamage)
    {
        _health -= healthDamage;
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

    // Start is called before the first frame update
    void Start()
    {
        health = _health;
        transform.position = _waypoints[0].transform.position;
        _agent.enabled = true;
        _agent.speed = _speed;
        _agent.destination = _waypoints[1].transform.position;
        _isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        Dead();
        if (_isAttacking == true)
        {
            _currentHealthOfTower--;
        }

        if (_currentHealthOfTower <= 0)
        {
            _isAttacking = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tower" || other.tag == "UpgradedTower")
        {
            _isAttacking = true;
            if (other.GetComponent<IDamagable>() != null)//
            {
               var fireClone = Instantiate(_fireTornado, transform.position, Quaternion.identity);
                fireClone.transform.position = other.transform.position;
                _currentHealthOfTower = other.GetComponent<IDamagable>().health;                                      
            }
        }

        else if (other.tag=="End")
        {
            UIManager.Instance.UpdateLives(10);
            Hide();
        }
    }

    public override void Dead()
    {
        if (_health <= 0 && _isDead == false)//best to check bool up here rather than down there.
        {
            _isDead = true;
            {
                _agent.enabled = false;
                UIManager.Instance.UpdateWarFunds(10000);
                var explosionClone = Instantiate(_explosion, transform.position, Quaternion.identity);
                Destroy(explosionClone, 0.5f);
                Invoke("Hide", 0.5f);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tower" || other.tag == "UpgradedTower")
        {
            Vector3 directionToFace = other.transform.position - _rotateTurret.transform.position;
            _rotateTurret.transform.rotation = Quaternion.LookRotation(directionToFace);           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _isAttacking = false;
    }
}
