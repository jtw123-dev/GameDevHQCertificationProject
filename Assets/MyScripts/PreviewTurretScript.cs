using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PreviewTurretScript : MonoBehaviour
{
    [SerializeField] Transform[] _transforms;
    [SerializeField] Renderer _renderer;
    public delegate void CanPlace(bool canIndeedPlace);
    public static event CanPlace _onClick;
    private bool _placeOnClick;

    public void CanIPlace(bool canPlace)
    {
        _placeOnClick = canPlace;
        if (_onClick != null)
        {
            _onClick(_placeOnClick);
        }
    }

    private void OnEnable()
    {
        CanIPlace(_placeOnClick);
    }


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
                    _onClick(false);
                    return;
                }

               else
                {
                    _onClick(true);
                    _renderer.material.color = Color.green;
                }
            }              
        }
    }
}
