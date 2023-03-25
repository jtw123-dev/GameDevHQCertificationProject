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
    //[SerializeField] private GameObject _preview;
    private bool _canPlace;
    [SerializeField] private GameObject _upgradeGatlingTowerUI, _upgradeMissileTurretUI;
    [SerializeField] private GameObject _dualGatlingGun, _dualMissileTurret;
    [SerializeField] private GameObject _towerToHoldForUpgrading;

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
                if (hitInfo.collider.tag=="UpgradedTower")
                {
                    return;
                }

                else if (hitInfo.collider.tag == "Tower")
                {     
                    if (_towerSelection==0)
                    {
                        if (UIManager.Instance.totalWarFunds>500)
                        {
                            _upgradeGatlingTowerUI.SetActive(true);
                            _towerToHoldForUpgrading = hitInfo.collider.gameObject;
                        }
                    }

                    else if (_towerSelection==1)
                    {
                        if (UIManager.Instance.totalWarFunds>750)
                        {
                            _upgradeMissileTurretUI.SetActive(true);
                            _towerToHoldForUpgrading = hitInfo.collider.gameObject;
                        }
                       
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
            hitInfo.collider.GetComponent<PlacementZoneScript>().ChangeParticleStatus();
            _currentObject = Instantiate(_towersCollection[_towerSelection]);
        }
    }
   //on clicking check tower instantiates right there
   // previous tower destroyed.
   //can't upgrade again.
    public void UpgradeTower()
    {
        if (_towerSelection==0)
        {
            Instantiate(_dualGatlingGun, _towerToHoldForUpgrading.transform.position, Quaternion.Euler(0, 90, 0));
            Destroy(_towerToHoldForUpgrading);
        }
      else if (_towerSelection ==1)
        {
            Instantiate(_dualMissileTurret, _towerToHoldForUpgrading.transform.position, Quaternion.Euler(0, 90, 0));
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
        if (Input.GetMouseButtonDown(0))//changed from 1
        {
            _currentObject = null;
        }
    }   
}
