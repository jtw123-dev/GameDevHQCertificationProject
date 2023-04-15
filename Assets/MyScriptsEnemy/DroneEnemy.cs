using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GameDevHQ.FileBase.Gatling_Gun;

public class DroneEnemy : Enemy,IDamagable
{
    public float health { get; set; }
    [SerializeField] private GameObject _galaxyExplosion;

    private void Update()
    {
        if (_health <= 0)
        {
            Dead();
        }
    }

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>(); //ssign the Audio Source to the reference variable
        _audioSource.loop = true; //making sure our sound effect loops
        health = _health;
        OnStartUp();
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
            StartCoroutine(WaitToExplode());
        }
        else if (other.tag == "End")
        {
            UIManager.Instance.UpdateLives(_livesToTake);
            Hide();
        }
    }
    private IEnumerator WaitToExplode()
    {
        yield return new WaitForSeconds(2);
        var galaxyClone = Instantiate(_galaxyExplosion, transform.position, Quaternion.identity);
        _audioSource.Play();
        Destroy(galaxyClone, 1);
        _health = 0;
        Dead();
    }
}
