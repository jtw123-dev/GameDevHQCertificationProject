using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class BasicMechEnemy : Enemy

{
    [SerializeField] private Renderer _renderer;
    private float _dissolving;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent.destination = _waypoints[1].transform.position;
        _renderer.sharedMaterial.SetFloat("_Clipping_value", 0);
 

       // _renderer.sharedMaterial.EnableKeyword("Clipping_value");
    }

    // Update is called once per frame
    void Update()
    {
        if (_health<=0)
        {
            _isDead = true;
        }
        if (_isDead==true)
        {
            StartCoroutine(DissolveRoutine());
            _agent.isStopped = true;
            Destroy(this.gameObject,2.5f);
           
        }
    }
    private IEnumerator DissolveRoutine()
    {
        while(true)
        {
            _dissolving += 0.1f *Time.deltaTime;
            
            
            _renderer.sharedMaterial.SetFloat("_Clipping_value", _dissolving);
            yield return new WaitForSeconds(0.2f);

        }
        

    }
}
