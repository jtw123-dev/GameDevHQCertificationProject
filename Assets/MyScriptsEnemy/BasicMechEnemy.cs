using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class BasicMechEnemy : Enemy,IDamagable

{
    [SerializeField] private Renderer[] _renderer;
   
    public float health { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _agent.destination = _waypoints[1].transform.position;
        
        health = _health;
        foreach(var obj in _renderer)
        {
            obj.material.SetFloat("_Clipping_value", 0);
        }
        _leftMuzzleFlash.SetActive(false); //setting the initial state of the muzzle flash effect to off
        _rightMuzzleFlash.SetActive(false);
        _audioSource = GetComponent<AudioSource>(); //ssign the Audio Source to the reference variable
        _audioSource.playOnAwake = false; //disabling play on awake
        _audioSource.loop = true; //making sure our sound effect loops
        _audioSource.clip = _fireSound; //assign the clip to play

    }
    private void OnEnable()
    {
        health = _health;
        _leftMuzzleFlash.SetActive(false); //setting the initial state of the muzzle flash effect to off
        _rightMuzzleFlash.SetActive(false);
        transform.position = _waypoints[0].transform.position;
        _agent.enabled = true;
        _agent.speed = _speed;
        _agent.destination = _waypoints[1].transform.position;
        _isDead = false;
        _anim.applyRootMotion = true;
        _health = 100;      
        StartCoroutine(ResetDissolve());
    }

    // Update is called once per frame
    void Update()
    {       
            Dead();     
        if (_isAttacking==true)
        {
          _currentHealthOfTower--;
        }

        if (_currentHealthOfTower <= 0)
        {
            _isAttacking = false;
            _leftMuzzleFlash.SetActive(false);
            _rightMuzzleFlash.SetActive(false);
            _audioSource.Stop(); //stop the sound effect from playing
        }
    }
     public override IEnumerator DissolveRoutine()
    {
        while(true)
        {
            _dissolving += 0.1f *Time.deltaTime;
            foreach(var obj in _renderer)
            {
                obj.material.SetFloat("_Clipping_value", _dissolving);
                yield return new WaitForSeconds(0.1f);
            }         
        }
    }

    public override IEnumerator ResetDissolve()
    {
        while (true)
        {
            foreach(var obj in _renderer)
            {
             obj.material.SetFloat("_Clipping_value", 0);//careful with shared material
                yield return new WaitForSeconds(0.2f);
            }         
        }
    }

    public void Damage(float healthDamage)
    {
        _health -= healthDamage;    
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tower" || other.tag == "UpgradedTower")
        {
            
          
            _isAttacking = true;
            if (other.GetComponent<IDamagable>() != null)//
            {
                _currentHealthOfTower = other.GetComponent<IDamagable>().health;
                other.GetComponent<IDamagable>().Damage(_attackDamage); //changing it to nearestEnemy made it work better rather than obj.              
                _leftMuzzleFlash.SetActive(true);
                _rightMuzzleFlash.SetActive(true);              
            }
            if (_startWeaponNoise == true) //checking if we need to start the gun sound
            {
                _audioSource.Play(); //play audio clip attached to audio source
                _startWeaponNoise = false; //set the start weapon noise value to false to prevent calling it again
            }
            Vector3 directionToFace = other.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(directionToFace);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _leftMuzzleFlash.SetActive(false);
        _rightMuzzleFlash.SetActive(false);
        _startWeaponNoise = true;
        _audioSource.Stop();
        _isAttacking = false;
    }

}
