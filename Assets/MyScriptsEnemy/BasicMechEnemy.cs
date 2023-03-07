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
        // _renderer = GetComponent<Renderer>();

        _renderer.sharedMaterial.EnableKeyword("Clipping_value");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_isDead==true)
        {
            float totalTime = 0.2f;
            Debug.Log("testing");
            float dissolving =  totalTime++;
            // _renderer.sharedMaterial.enabledKeywords;

            // _renderer.sharedMaterial.shader = Shader.Find("Shader Graphs/Dissolve");


            _renderer.sharedMaterial.SetFloat("_Clipping_value", dissolving);
            Destroy(this.gameObject,2);
           
        }
    }

    void CheckShaderKeyWordState()
    {
        //var shader = material
    }
}
