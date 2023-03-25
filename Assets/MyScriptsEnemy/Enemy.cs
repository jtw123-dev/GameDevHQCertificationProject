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

    public virtual void EnemyAttack()

    {

    }

    public virtual void Movement()
    {

    }

    public void Hide()
    {
        _agent.enabled = false;
        this.gameObject.SetActive(false);       
    }
   
    public  void Dead()
    {
        if (_health <= 0)
        {
            _audioSource.Stop();
            _anim.applyRootMotion = false;
            _leftMuzzleFlash.SetActive(false);
            _rightMuzzleFlash.SetActive(false);
            StartCoroutine(DissolveRoutine());
            _agent.enabled = false;
            _anim.SetTrigger("Death");
            Invoke("Hide", 2.5f);//Destroy instead of hide for enemies that die
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
    public void FindTowerToAttack()
    {
        //may have to include logic if there are no towers.
       // foreach (var obj in GameObject.FindGameObjectsWithTag("Tower"))
       // {
            //is only caring about the first tower and nothing else
            //try using colliders this will allow you to grab the reference to it and than attack it specifically
            //this is because var nearestEnemy = GetComponenet<Tower>().towers[0];is singular not plural like the below
           // var nearestEnemy = GameObject.FindGameObjectWithTag("Tower");
            //var nearestEnemy = GameObject.FindGameObjectsWithTag("Tower")[0];
            //if (Vector3.Distance(obj.transform.position, transform.position) < Vector3.Distance(nearestEnemy.transform.position, transform.position))
           // {
          //      nearestEnemy = obj;
           // }
            

           // float dist = Vector3.Distance(nearestEnemy.transform.position, transform.position);

            /*if (dist < 5)
            {
                nearestEnemy.GetComponent<Tower>().Damage(); //changing it to nearestEnemy made it work better rather than obj.
                _leftMuzzleFlash.SetActive(true);
                _rightMuzzleFlash.SetActive(true);
                if (_startWeaponNoise == true) //checking if we need to start the gun sound
                {
                    _audioSource.Play(); //play audio clip attached to audio source
                    _startWeaponNoise = false; //set the start weapon noise value to false to prevent calling it again
                }
                Vector3 directionToFace = obj.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(directionToFace);            
            }*/
           // else if (dist > 5)
            //{
                //_leftMuzzleFlash.SetActive(false);
                // _rightMuzzleFlash.SetActive(false);
                //_startWeaponNoise = true;
                //_audioSource.Stop();
         //   }
    
           
     //   }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Tower"||other.tag=="UpgradedTower")
        {
            
            Debug.Log("Attacking enemy");         
                other.GetComponent<Tower>().Damage(1); //changing it to nearestEnemy made it work better rather than obj.
                _leftMuzzleFlash.SetActive(true);
                _rightMuzzleFlash.SetActive(true);
                if (_startWeaponNoise == true) //checking if we need to start the gun sound
                {
                    _audioSource.Play(); //play audio clip attached to audio source
                    _startWeaponNoise = false; //set the start weapon noise value to false to prevent calling it again
                }
                Vector3 directionToFace = other.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(directionToFace);       
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="End")
        {
            Hide();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _leftMuzzleFlash.SetActive(false);
        _rightMuzzleFlash.SetActive(false);
        _startWeaponNoise = true;
        _audioSource.Stop();
    }
}
