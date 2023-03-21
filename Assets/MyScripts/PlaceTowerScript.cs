using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlaceTowerScript : MonoBehaviour
{
    [SerializeField] private GameObject _gatlingGun;
    [SerializeField]private bool _showParticles;
    [SerializeField] private GameObject[] _towersCollection;
    private int _towerSelection;
    private GameObject _currentObject;
    [SerializeField]private bool _isOnZone;

    // Update is called once per frame
    void Update()
    {
        HandleTower();

        if(_currentObject!=null)
        {
            MoveCurrentObjectToMouse();
            ReleaseIfClicked();
            //CheckIfTowerExists();
        }
    }

    private void CheckIfTowerExists()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.tag == "Tower")
            {
                Debug.Log("hit tower");
              
                
            }
            // _previewTower.transform.position = hitInfo.point;
            //_turretPreviews[_towerSelection].transform.position = hitInfo.point;
        }
    }

    private void HandleTower()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.tag == "Tower")
                {
                    return;
                }
                else if (hitInfo.collider.tag!="Zone")
                {
                    return;
                }

                else if (UIManager.Instance.totalWarFunds<200)
                {
                    return;
                }
            }

            PlacementZoneScript.onSelect += TowerSelected;
            //  _currentObject = Instantiate(_gatlingGun); 
            hitInfo.collider.GetComponent<PlacementZoneScript>().ChangeParticleStatus();
            _currentObject = Instantiate(_towersCollection[_towerSelection]);
        }
    }

    private void TowerSelected(int tower)
    {
        _towerSelection = tower;
    }
    

    public void MoveCurrentObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.tag == "Zone")
            {
                _currentObject.transform.position = hitInfo.point;
            }
        }
    }
    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))//changed from 1
        {
            _currentObject = null;
        }
    }   
}
