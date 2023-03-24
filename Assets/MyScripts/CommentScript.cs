using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentScript : MonoBehaviour
{
    //From placeTowerScript
    /* RaycastHit hitData;
       RaycastHit contHitData;
       Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);

       if (Input.GetMouseButtonDown(0))
       {
           if (Physics.Raycast(rayOrigin, out hitData))
           {             
               _hitPosition = hitData.point;
               _gatlingGunClone = Instantiate(_gatlingGun, _hitPosition, Quaternion.identity);
               _gatlingGunClone.transform.position = hitData.point;               
           }
       }

       if (Physics.Raycast(rayOrigin, out contHitData))
       {
           if (contHitData.collider.transform.tag=="Zone")
           {

               _hitPosition = contHitData.point;


              // Instantiate(_gatlingGunPreview, _hitPosition, Quaternion.identity);
              // _gatlingGunPreview.transform.position = contHitData.point;
           }                   
       }


   */


    //void OnMouseDrag()
    // {
    //   Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
    //   cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
    //   transform.position = cursorPosition;
    //  }

    //private GameObject _gatlingGunClone;
    //private Vector3 _hitPosition;
    // private Vector3 _screenPoint, _offset;
    // [SerializeField] private Renderer _rend;
    // private Vector3 _cursorPosition;
    //private PlacementZoneScript _zoneScript;

    //This is from placement zone script
    /* private void OnMouseEnter()
        {
            _screenPoint = Camera.main.WorldToScreenPoint(_previewTower.transform.position);
            _offset = _previewTower.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
            _previewTower.SetActive(true);
        }

        private void OnMouseDrag()
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + _offset;
            _previewTower.transform.position = cursorPosition;
        }

        private void OnMouseOver()
        {
            _screenPoint = Camera.main.WorldToScreenPoint(_previewTower.transform.position);
            _offset = _previewTower.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
           Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + _offset;
            _previewTower.transform.position = cursorPosition;
           // _previewTower.transform.position = Camera.main.ScreenToWorldPoint( Input.mousePosition);
        }

        public void OnMouseExit()
        {
            _previewTower.transform.position = _startingPos.position;
           _previewTower.SetActive(false);
        }
        */

    //placement zone script tower script
    //  //if(_isActive==true)
    // {
    //     return;
    // }
    // else
    //  // _isActive = true;   


    //this is from enemy

    /*if (_isDead == true)
       {//add bool to see if he can resurect
           _anim.applyRootMotion = false;
           _leftMuzzleFlash.SetActive(false);
           _rightMuzzleFlash.SetActive(false);
           StartCoroutine(DissolveRoutine());
           _agent.enabled = false;
           _anim.SetTrigger("Death");

           //Destroy(this.gameObject, 2.5f);
           Invoke("Hide",2.5f);//Destroy instead of hide for enemies that die
           //is dead and health is 0 or less is different
       }*/

}
