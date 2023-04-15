using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace GameDevHQ.FileBase.Gatling_Gun
{
    /// <summary>
    /// This script will allow you to view the presentation of the Turret and use it within your project.
    /// Please feel free to extend this script however you'd like. To access this script from another script
    /// (Script Communication using GetComponent) -- You must include the namespace (using statements) at the top. 
    /// "using GameDevHQ.FileBase.Gatling_Gun" without the quotes. 
    /// 
    /// For more, visit GameDevHQ.com
    /// 
    /// @authors
    /// Al Heck
    /// Jonathan Weinberger
    /// </summary>

    [RequireComponent(typeof(AudioSource))] //Require Audio Source component
    public class Gatling_Gun :Tower,IDamagable
    {
        [SerializeField] private Transform _gunBarrel; //Reference to hold the gun barrel
        [SerializeField] GameObject _muzzleFlash; //reference to the muzzle flash effect to play when firing
        [SerializeField] private ParticleSystem _bulletCasings; //reference to the bullet casing effect to play when firing
        [SerializeField] private AudioClip _fireSound; //Reference to the audio clip
        private AudioSource _audioSource; //reference to the audio source component
        private bool _startWeaponNoise = true;
        private GameObject _currentAttackedObject;
        private bool _isUpgraded;
        [SerializeField] private float _attackDamage;
        public float health { get; set; }
    
        private void OnEnable()
        {
            _muzzleFlash.SetActive(false); //setting the initial state of the muzzle flash effect to off
            _audioSource = GetComponent<AudioSource>(); //ssign the Audio Source to the reference variable
            _audioSource.playOnAwake = false; //disabling play on awake
            _audioSource.loop = true; //making sure our sound effect loops
            _audioSource.clip = _fireSound; //assign the clip to play
            health = _health;
        }
        private void Update()
        {
            if (_isAttacking == true)
            {
                _currentHealthOfEnemy--;
            }

            if (_currentHealthOfEnemy <= 0)
            {
                _isAttacking = false;
                _inColliderGameObjects.Remove(_currentAttackedObject);
                _muzzleFlash.SetActive(false);
                _audioSource.Stop(); //stop the sound effect from playing
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Tornado")
            {
                return;
            }
            _inColliderGameObjects.Add(other.gameObject);
            _startWeaponNoise = true;
            _currentAttackedObject = other.gameObject;
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Enemy" && _isDead == false)
            {
                foreach (var obj in _inColliderGameObjects)
                {

                    if (this.gameObject != null && obj != null)
                    {
                        float distance = Vector3.Distance(this.gameObject.transform.position, obj.transform.position);
                        if (distance <= 5)
                        {
                            _currentAttackedObject = obj;
                        }
                    }
                }

                if (_currentAttackedObject != null)
                {
                    _isAttacking = true;
                    _currentHealthOfEnemy = other.GetComponent<IDamagable>().health;
                    _currentAttackedObject.GetComponent<IDamagable>().Damage(_attackDamage);
                    RotateBarrel(); //Call the rotation function responsible for rotating our gun barrel
                    _muzzleFlash.SetActive(true); //enable muzzle effect particle effect
                    _bulletCasings.Emit(1); //        
                    Vector3 directionToFace = _currentAttackedObject.transform.position - _rotateTurret.position;
                    _rotateTurret.transform.rotation = Quaternion.LookRotation(directionToFace);
                }
                if (_currentAttackedObject.GetComponent<IDamagable>().health <= 0 && _currentAttackedObject != null&&this.gameObject!=null)//this does not work as else if 
                {
                    _inColliderGameObjects.Remove(_currentAttackedObject);
                    _muzzleFlash.SetActive(false);
                    _audioSource.Stop(); //stop the sound effect from playing
                }

                if (_startWeaponNoise == true) //checking if we need to start the gun sound
                {
                    _audioSource.Play(); //play audio clip attached to audio source
                    _startWeaponNoise = false; //set the start weapon noise value to false to prevent calling it again
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            _inColliderGameObjects.Remove(other.gameObject);
            _muzzleFlash.SetActive(false); //turn off muzzle flash particle effect
            _audioSource.Stop(); //stop the sound effect from playing
            _startWeaponNoise = true; //set the start weapon noise value to true
        }

        // Method to rotate gun barrel 
        void RotateBarrel()
        {
            _gunBarrel.transform.Rotate(Vector3.forward * Time.deltaTime * -500.0f); //rotate the gun barrel along the "forward" (z) axis at 500 meters per second
        }
    }
}
