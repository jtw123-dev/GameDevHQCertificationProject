using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class BasicMechEnemy : Enemy

{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Transform _target;
    private float _dissolving;
    [SerializeField] private bool _slowDown;
    
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
     
        //create a list of towers and choose which one to attack by distance via foreach loop



        Vector3 directionToFace = _target.position - transform.position;
        Debug.DrawRay(transform.position, directionToFace, Color.red);
       // Ray rayOrigin = new Ray (transform.position,transform.forward);
       // RaycastHit hit;
        //Debug.DrawRay(rayOrigin.origin, directionToFace,Color.black);
       // if (Physics.Raycast(rayOrigin,out hit,1))
       // {
       //     Debug.Log("hit someting");
       // }

        transform.rotation = Quaternion.LookRotation(directionToFace);


        if (_slowDown ==true)
        {
            Time.timeScale = 0.5f;
        }

        if (_health<=0)
        {
            _isDead = true;
            _anim.applyRootMotion = false;
        }
        if (_isDead==true)
        {
            _anim.applyRootMotion = false;
            StartCoroutine(DissolveRoutine());
            _agent.isStopped = true;
            _anim.SetTrigger("Death");
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
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Tower")
        {
            Debug.Log("Attacking");
        }
    }
    public override void  EnemyAttack()
    {

    }
}
