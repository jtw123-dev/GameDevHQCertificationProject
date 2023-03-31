using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneEnemy : Enemy,IDamagable
{
    public float health { get ; set; }
    [SerializeField] private GameObject _galaxyExplosion;
    

    // Start is called before the first frame update
    void Start()
    {
        _agent.destination = _waypoints[1].transform.position;

        health = _health;
    }
    private void Update()
    {
        Dead();
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
    public override void Dead()
    {
        if (_health <= 0 && _isDead == false)//best to check bool up here rather than down there.
        {
            _isDead = true;
            {

                _agent.enabled = false;
                UIManager.Instance.UpdateWarFunds(150);
                Invoke("Hide", 0.5f);
            }
        }
    }

    public void Damage(float healthDamage)
    {
        _health -= healthDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tower" || other.tag == "UpgradedTower")
        {
            if (other.GetComponent<IDamagable>() == null)
            {         
                return;
            }
            other.GetComponent<IDamagable>().Damage(_attackDamage);                      
            Vector3 directionToFace = other.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(directionToFace);
            Instantiate(_galaxyExplosion,transform.position,Quaternion.identity);
            _health = 0;
            Dead();
        }
}
}
