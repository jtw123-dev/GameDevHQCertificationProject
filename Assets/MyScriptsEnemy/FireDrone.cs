using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDrone : Enemy,IDamagable
{
    public float health { get; set; }
    [SerializeField] private GameObject _windTornado;

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

    private void OnEnable()
    {
        health = _health;
        transform.position = _waypoints[0].transform.position;
        _agent.enabled = true;
        _agent.speed = _speed;
        _agent.destination = _waypoints[1].transform.position;
        _isDead = false;
    }    // Update is called once per frame
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
            _windTornado.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tower" || other.tag == "UpgradedTower")
        {
            _windTornado.SetActive(true);
            _isAttacking = true;
            if (other.GetComponent<IDamagable>() != null)//
            {
                _currentHealthOfTower = other.GetComponent<IDamagable>().health;
                other.GetComponent<IDamagable>().Damage(_attackDamage); //changing it to nearestEnemy made it work better rather than obj.                           
            }          
            Vector3 directionToFace = other.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(directionToFace);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _windTornado.SetActive(false);
        _isAttacking = false;
    }
}
