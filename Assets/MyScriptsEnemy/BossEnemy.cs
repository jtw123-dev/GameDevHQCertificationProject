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
    }

    // Start is called before the first frame update
    void Start()
    {
        health = _health;
        OnStartUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (_health <= 0)
        {
            Dead();
            var explosionClone = Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(explosionClone, 0.5f);
        }

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
            if (other.GetComponent<IDamagable>() != null)
            {
                var fireClone = Instantiate(_fireTornado, transform.position, Quaternion.identity);
                fireClone.transform.position = other.transform.position;
                _currentHealthOfTower = other.GetComponent<IDamagable>().health;
            }
        }

        else if (other.tag == "End")
        {
            UIManager.Instance.UpdateLives(_livesToTake);
            Hide();
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
