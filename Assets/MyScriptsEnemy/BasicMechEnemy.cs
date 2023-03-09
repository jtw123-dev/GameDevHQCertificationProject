using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class BasicMechEnemy : Enemy

{
    [SerializeField] private Renderer _renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent.destination = _waypoints[1].transform.position;
        _renderer.sharedMaterial.SetFloat("_Clipping_value", 0);

        _leftMuzzleFlash.SetActive(false); //setting the initial state of the muzzle flash effect to off
        _rightMuzzleFlash.SetActive(false);
        _audioSource = GetComponent<AudioSource>(); //ssign the Audio Source to the reference variable
        _audioSource.playOnAwake = false; //disabling play on awake
        _audioSource.loop = true; //making sure our sound effect loops
        _audioSource.clip = _fireSound; //assign the clip to play

    }

    // Update is called once per frame
    void Update()
    {
        FindTowerToAttack();
        Dead();   
    }
     public override IEnumerator DissolveRoutine()
    {
        while(true)
        {
            _dissolving += 0.1f *Time.deltaTime;
            _renderer.sharedMaterial.SetFloat("_Clipping_value", _dissolving);
            yield return new WaitForSeconds(0.2f);
        }
    }

    
}
