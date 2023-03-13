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
    [SerializeField] protected AudioClip _fireSound;
    [SerializeField] protected GameObject _leftMuzzleFlash,_rightMuzzleFlash;
    protected AudioSource _audioSource;
    protected bool _startWeaponNoise;
    protected float _dissolving;
    protected Tower _towerReference;
    
    
    
    // protected Renderer _renderer;

    //Use timescale to speed up and slow down game

    //took out onenable


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

    public virtual void Dead()
    {
        if (_health <= 0)
        {
            _isDead = true;
            _anim.applyRootMotion = false;
            Hide();
        }
        if (_isDead == true)
        {//add bool to see if he can resurect
            SpawnManager.Instance.MechHasDied();
            _anim.applyRootMotion = false;          
            StartCoroutine(DissolveRoutine());
            _agent.enabled = false;
            _anim.SetTrigger("Death");
            //Destroy(this.gameObject, 2.5f);
            Invoke("Hide",2.5f);//Destroy instead of hide for enemies that die

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
        if (other.tag=="Tower")
        {
           // if (_isDead==true)
           // {
            //    return;
           // }
           // else if (_isDead==false)
            //{
                other.GetComponent<Tower>().Damage(); //changing it to nearestEnemy made it work better rather than obj.
                _leftMuzzleFlash.SetActive(true);
                _rightMuzzleFlash.SetActive(true);
                if (_startWeaponNoise == true) //checking if we need to start the gun sound
                {
                    _audioSource.Play(); //play audio clip attached to audio source
                    _startWeaponNoise = false; //set the start weapon noise value to false to prevent calling it again
                }
                Vector3 directionToFace = other.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(directionToFace);
          // }          
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
//Debug.DrawRay(transform.position, directionToFace, Color.red);