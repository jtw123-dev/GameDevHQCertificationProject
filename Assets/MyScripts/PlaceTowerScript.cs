using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using GameDevHQ.FileBase.Gatling_Gun;

public class PlaceTowerScript : MonoBehaviour
{
    [SerializeField] private GameObject _gatlingGun;
    [SerializeField]private bool _showParticles;
    [SerializeField] private GameObject[] _towersCollection;
    private int _towerSelection;
    private GameObject _currentObject;
    [SerializeField]private bool _isOnZone;
    private bool _canPlace;
    [SerializeField] private GameObject _upgradeGatlingTowerUI, _upgradeMissileTurretUI;
    [SerializeField] private GameObject _dualGatlingGun, _dualMissileTurret;
    [SerializeField] private GameObject _towerToHoldForUpgrading;
    private int _currentCost =200;
    
    // Update is called once per frame
    void Update()
    {
        HandleTower();

        if(_currentObject!=null)
        {
            MoveCurrentObjectToMouse();
            ReleaseIfClicked();
        }
    }

    private void CanPlaceTower(bool canPlace )
    {
        _canPlace = canPlace;
    }

    private void TowerSelected(int tower)
    {
        _towerSelection = tower;
        if (_towerSelection == 0)
        {
            _currentCost = 200;
        }
        else if (_towerSelection == 1)
        {
            _currentCost = 500;
        }
    }

    private void OnDisable()
    {
        PlacementZoneScript.onSelect -= TowerSelected;
        PreviewTurretScript._onClick -= CanPlaceTower;
    }
    private void HandleTower()
    {
    //moved other delegate below    
        PreviewTurretScript._onClick += CanPlaceTower;
        if ( Mouse.current.leftButton.wasPressedThisFrame)
        {
            PlacementZoneScript.onSelect += TowerSelected;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            PreviewTurretScript._onClick += CanPlaceTower;
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.tag=="UpgradedTower")
                {
                    return;
                }

                else if (hitInfo.collider.tag == "Tower")
                {     
                    if (_towerSelection==0)
                    {                
                            _upgradeGatlingTowerUI.SetActive(true);
                            _towerToHoldForUpgrading = hitInfo.collider.gameObject;
                    }

                    else if (_towerSelection==1)
                    {                     
                            _upgradeMissileTurretUI.SetActive(true);
                            _towerToHoldForUpgrading = hitInfo.collider.gameObject;  
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
            }
            PlacementZoneScript.onSelect += TowerSelected;
            if (UIManager.Instance.UpdateWarFundsAfterTowerBuy(_currentCost)==true)
            {
                _currentObject = Instantiate(_towersCollection[_towerSelection],transform.position,Quaternion.Euler(0,-90,0));
                hitInfo.collider.GetComponent<PlacementZoneScript>().ChangeParticleStatus();
            }         
        }
    }
    public void UpgradeTower()
    {
        if (_towerSelection==0 &&UIManager.Instance.UpdateWarFundsAfterTowerBuy(500)==true &&_towerToHoldForUpgrading!=null)
        {
            Instantiate(_dualGatlingGun, _towerToHoldForUpgrading.transform.position, Quaternion.Euler(0, -90, 0));
            Destroy(_towerToHoldForUpgrading);
        }
      else if (_towerSelection ==1 && UIManager.Instance.UpdateWarFundsAfterTowerBuy(750)==true&&_towerToHoldForUpgrading!=null)
        {
            Instantiate(_dualMissileTurret, _towerToHoldForUpgrading.transform.position, Quaternion.Euler(0, -90, 0));
            Destroy(_towerToHoldForUpgrading);
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
        if ( Mouse.current.leftButton.wasPressedThisFrame) //Input.GetMouseButtonDown(0))//changed from 1
        {
            _currentObject = null;
        }
    }   
}
