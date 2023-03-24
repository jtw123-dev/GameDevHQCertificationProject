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
    [SerializeField] private GameObject _preview;
    private bool _canPlace;
    [SerializeField] private GameObject _upgradeGatlingTower, _upgradeMissileTurret;

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

    private void CanPlaceTower(bool canPlace )
    {
        _canPlace = canPlace;
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


    private void TowerSelected(int tower)
    {
        _towerSelection = tower;
    }

    private void HandleTower()
    {
        PlacementZoneScript.onSelect += TowerSelected;
        PreviewTurretScript._onClick += CanPlaceTower;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            PreviewTurretScript._onClick += CanPlaceTower;
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.tag == "Tower")
                {     
                    if (_towerSelection==0)
                    {
                        _upgradeGatlingTower.SetActive(true);

                    }

                    else if (_towerSelection==1)
                    {
                        _upgradeMissileTurret.SetActive(true);
                    }
                    return;
                }
                else if (hitInfo.collider.tag!="Zone")
                {
                    return;
                }
               
                else if (_canPlace==false)
                {
                    return;
                }
                else if (UIManager.Instance.totalWarFunds<200)
                {
                    return;
                }
            }

            PlacementZoneScript.onSelect += TowerSelected;
            Debug.Log(_towerSelection);
            //  _currentObject = Instantiate(_gatlingGun); 
            hitInfo.collider.GetComponent<PlacementZoneScript>().ChangeParticleStatus();
            _currentObject = Instantiate(_towersCollection[_towerSelection]);
        }
    }
   
    public void UpgradeTower()
    {
        if (_towerSelection==0)

        {
           // _currentObject = Instantiate()
        }

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
