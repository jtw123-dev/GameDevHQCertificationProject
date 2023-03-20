using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlacementZoneScript : MonoBehaviour
{
  
    [SerializeField] private GameObject[] _turretPreviews;
    public delegate void TowerSelecting(int towerSelected);
    public static event TowerSelecting onSelect;
    private static bool _isActive;
    [SerializeField]private static   int _towerSelection; //important to keep static
       

    
    // Update is called once per frame
    void Update()
    {      
        if (Input.GetMouseButtonDown(1))
        {
            _turretPreviews[_towerSelection].SetActive(false);          
        }
    }

   
    public void SwitchTowerSelection(int towerSelected)
    {
        _towerSelection = towerSelected;
        if (onSelect!=null)
        {
            onSelect(_towerSelection);
          //  _towerSelection = towerSelected;
        }
    }
 
    private void OnMouseEnter()
    {
        if(_isActive==true)
        {
            return;
        }
        else
        {
            _turretPreviews[_towerSelection].SetActive(true);
            _isActive = true;
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
        _isActive = false;
        _turretPreviews[_towerSelection].SetActive(false);
    }       
    }
