using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameDevHQ.FileBase.Dual_Gatling_Gun
{
    /// <summary>
    /// This script will allow you to view the presentation of the Turret and use it within your project.
    /// Please feel free to extend this script however you'd like. To access this script from another script
    /// (Script Communication using GetComponent) -- You must include the namespace (using statements) at the top. 
    /// "using GameDevHQ.FileBase.Dual_Gatling_Gun" without the quotes. 
    /// 
    /// For more, visit GameDevHQ.com
    /// 
    /// @authors
    /// Al Heck
    /// Jonathan Weinberger
    /// </summary>

    [RequireComponent(typeof(AudioSource))] //Require Audio Source component
    public class Dual_Gatling_Gun : Tower,IDamagable
    {
        [SerializeField]
        private Transform[] _gunBarrel; //Reference to hold the gun barrel
        [SerializeField]
        private GameObject[] _muzzleFlash; //reference to the muzzle flash effect to play when firing
        [SerializeField]
        private ParticleSystem[] _bulletCasings; //reference to the bullet casing effect to play when firing
        [SerializeField]
        private AudioClip _fireSound; //Reference to the audio clip

        private AudioSource _audioSource; //reference to the audio source component
        private bool _startWeaponNoise = true;


        //[SerializeField] private List<GameObject> _inColliderGameObjects = new List<GameObject>();
       // [SerializeField] private Transform _rotateTurret;
        [SerializeField] private GameObject _currentAttackedObject;
    //    [SerializeField] private float _health;
     //   [SerializeField] private GameObject _explosion;
        public float health { get; set; }
      //  private bool _isDead;

        // Use this for initialization
        void OnEnable()//changed from start
        {
            health = _health;
            _isDead = false;
            _muzzleFlash[0].SetActive(false); //setting the initial state of the muzzle flash effect to off
            _muzzleFlash[1].SetActive(false); //setting the initial state of the muzzle flash effect to off
            _audioSource = GetComponent<AudioSource>(); //ssign the Audio Source to the reference variable
            _audioSource.playOnAwake = false; //disabling play on awake
            _audioSource.loop = true; //making sure our sound effect loops
            _audioSource.clip = _fireSound; //assign the clip to play
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("dual is triggered");
            _inColliderGameObjects.Add(other.gameObject);
            _startWeaponNoise = true;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Enemy"&&_isDead==false)
            {
                foreach (var obj in _inColliderGameObjects)
                {
                    float distance = Vector3.Distance(this.gameObject.transform.position, obj.transform.position);
                    if (distance <= 5)
                    {
                        _currentAttackedObject = obj;
                        obj.GetComponent<IDamagable>().health--;
                    }
                }

                if (_currentAttackedObject != null)
                {
                    _currentAttackedObject.GetComponent<IDamagable>().Damage(0.4f);//changed from 0.2f
                    Vector3 directionToFace = _currentAttackedObject.transform.position - _rotateTurret.position;
                    _rotateTurret.transform.rotation = Quaternion.LookRotation(directionToFace);
                }
                if (_currentAttackedObject.GetComponent<IDamagable>().health <= 0)
                {
                    _inColliderGameObjects.Remove(_currentAttackedObject);
                    _muzzleFlash[0].SetActive(false); //setting the initial state of the muzzle flash effect to off
                    _muzzleFlash[1].SetActive(false);
                    Debug.Log("stopped");
                    _audioSource.Stop(); //stop the sound effect from playing
                }
                else if (_currentAttackedObject.GetComponent<IDamagable>().health > 0)
                {
                    for (int i = 0; i < _muzzleFlash.Length; i++)
                    {
                        _muzzleFlash[i].SetActive(true); //enable muzzle effect particle effect
                        _bulletCasings[i].Emit(1); //Emit the bullet casing particle effect   
                    }
                    RotateBarrel(); //Call the rotation function responsible for rotating our gun barrel
                  //  _muzzleFlash[0].SetActive(true); //setting the initial state of the muzzle flash effect to off
                  
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
            for (int i = 0; i < _muzzleFlash.Length; i++)
            {
                _muzzleFlash[i].SetActive(false); //enable muzzle effect particle effect
            }
            _audioSource.Stop(); //stop the sound effect from playing
            _startWeaponNoise = true; //set the start weapon noise value to true
        }
      
        // Method to rotate gun barrel 
        void RotateBarrel() 
        {
            _gunBarrel[0].transform.Rotate(Vector3.forward * Time.deltaTime * -500.0f); //rotate the gun barrel along the "forward" (z) axis at 500 meters per second
            _gunBarrel[1].transform.Rotate(Vector3.forward * Time.deltaTime * -500.0f); //rotate the gun barrel along the "forward" (z) axis at 500 meters per second
        }

      
    }

}
