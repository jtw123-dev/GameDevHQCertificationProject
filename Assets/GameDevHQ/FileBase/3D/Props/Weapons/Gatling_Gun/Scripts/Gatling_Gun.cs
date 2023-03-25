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
    public class Gatling_Gun : MonoBehaviour
    {
        [SerializeField]private Transform _gunBarrel; //Reference to hold the gun barrel
        [SerializeField] private List<GameObject> _inColliderGameObjects = new List<GameObject>();
        public GameObject Muzzle_Flash; //reference to the muzzle flash effect to play when firing
        public ParticleSystem bulletCasings; //reference to the bullet casing effect to play when firing
        public AudioClip fireSound; //Reference to the audio clip

        private AudioSource _audioSource; //reference to the audio source component
        private bool _startWeaponNoise = true;
        [SerializeField] private Transform _rotateTurret;
        [SerializeField]private GameObject _currentAttackedObject;
        private bool _isUpgraded;

        // Use this for initialization
        void Start()
        {
            Muzzle_Flash.SetActive(false); //setting the initial state of the muzzle flash effect to off
            _audioSource = GetComponent<AudioSource>(); //ssign the Audio Source to the reference variable
            _audioSource.playOnAwake = false; //disabling play on awake
            _audioSource.loop = true; //making sure our sound effect loops
            _audioSource.clip = fireSound; //assign the clip to play
        }
        //might need to disable list 
  
        private void OnTriggerEnter(Collider other)
        {
            _inColliderGameObjects.Add(other.gameObject);
            _startWeaponNoise = true;
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.tag=="Enemy")
            {
               // Enemy._enemyDeath += IsMechDead;//
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
                    _currentAttackedObject.GetComponent<IDamagable>().Damage(0.2f);
                }
                if (_currentAttackedObject.GetComponent<IDamagable>().health<=0)
                {
                    _inColliderGameObjects.Remove(_currentAttackedObject);
                    Muzzle_Flash.SetActive(false);
                    _audioSource.Stop(); //stop the sound effect from playing
                }
                else if (_currentAttackedObject.GetComponent<IDamagable>().health > 0)
                {
                    RotateBarrel(); //Call the rotation function responsible for rotating our gun barrel
                    Muzzle_Flash.SetActive(true); //enable muzzle effect particle effect
                    bulletCasings.Emit(1); //Emit the bullet casing particle effect        
                }

                if (_startWeaponNoise == true) //checking if we need to start the gun sound
                {
                    _audioSource.Play(); //play audio clip attached to audio source
                    _startWeaponNoise = false; //set the start weapon noise value to false to prevent calling it again
                }
  
                //Vector3 directionToFace = other.transform.position - _rotateTurret.position;
                if (_currentAttackedObject!=null)
                {
                    Vector3 directionToFace = _currentAttackedObject.transform.position - _rotateTurret.position;
                    _rotateTurret.transform.rotation = Quaternion.LookRotation(directionToFace);
                }
            }          
        }
        private void OnTriggerExit(Collider other)
        {
            _inColliderGameObjects.Remove(other.gameObject);          
            Muzzle_Flash.SetActive(false); //turn off muzzle flash particle effect
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
