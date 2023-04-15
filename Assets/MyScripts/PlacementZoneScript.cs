using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.InputSystem;

public class PlacementZoneScript : MonoBehaviour
{ 
    [SerializeField] private GameObject[] _turretPreviews;
    [SerializeField] private List<GameObject> _availablePlacements;
    public delegate void TowerSelecting(int towerSelected);
    public static event  TowerSelecting onSelect;
    private static bool _isActive;
    [SerializeField]private bool _playParticles =true;
    [SerializeField]private static   int _towerSelection; //important to keep static
         
    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            _turretPreviews[_towerSelection].SetActive(false);
        }
    }

    public bool ChangeParticleStatusToTrue()
    {
        _playParticles = true;
        return _playParticles;
    }

    public bool  ChangeParticleStatus()
    {
        _playParticles = false;
        return _playParticles;      
    }

    public void SwitchTowerSelection(int towerSelected)
    {
        _towerSelection = towerSelected;
        if (onSelect!=null)
        {
            onSelect(_towerSelection);
        }
    }

    private void ParticlesOnOff(bool check)
    {
        _playParticles = check;
    }
 
    private void OnMouseEnter()
    {  
            _turretPreviews[_towerSelection].SetActive(true);                       
            var result = _availablePlacements.Where(n => n.GetComponentInParent<PlacementZoneScript>()._playParticles == true);
            foreach(var obj in result)
            {
                obj.gameObject.SetActive(true);
            }                     
    }
    private void OnMouseOver()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            _turretPreviews[_towerSelection].transform.position = hitInfo.point;
        }
    }

    private void OnMouseExit()
    {
        foreach (var obj in _availablePlacements)
        {   
            obj.SetActive(false);
        }   
        _turretPreviews[_towerSelection].SetActive(false);
    }       
    }
