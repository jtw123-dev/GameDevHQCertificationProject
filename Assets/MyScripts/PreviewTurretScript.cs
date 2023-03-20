using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewTurretScript : MonoBehaviour
{
    [SerializeField] Transform[] _transforms;
    [SerializeField] Renderer _renderer;
   
    // Update is called once per frame
    void Update()
    {
        foreach(var obj in _transforms)
        {         
            Ray ray = new Ray(obj.transform.position, Vector3.down);
            RaycastHit hitInfo;
     
            if (Physics.Raycast(ray,out hitInfo))
            {                             
                if (hitInfo.collider.tag != "Zone")           
                {
                    _renderer.material.color = Color.red;
                    return;
                }

               else
                {
                    _renderer.material.color = Color.green;
                }
            }              
        }
    }
}
