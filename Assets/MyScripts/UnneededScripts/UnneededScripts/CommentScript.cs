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


    //this is from camera script
    /*
       if (Input.GetKey(KeyCode.W))
       {        
           if (transform.position.y<=_cameraMaxY)

           {
               //_speed += 0.1f;
              // transform.Translate(Vector3.up * Time.deltaTime * _speed);
           }         
       }
       else if (Input.GetKeyUp(KeyCode.W))
       {
          // _speed = 1;
       }
       else if (Input.GetKey(KeyCode.S))
       {
           if(transform.position.y>=_cameraMinY)   
           {
               _speed += 0.1f;
               transform.Translate(Vector3.down * Time.deltaTime * _speed);
           }          
       }

       else if (Input.GetKeyUp(KeyCode.S))
       {
           _speed = 1;
       }

       else if (Input.GetKey(KeyCode.A))
       {
           if (transform.position.z<=_cameraMaxZ)
           {
               _speed += 0.1f;
               transform.Translate(Vector3.left * Time.deltaTime * _speed);
           }        
       }

       else if (Input.GetKeyUp(KeyCode.A))
       {
           _speed = 1;
       }


       else if (Input.GetKey(KeyCode.D))
       {
          if (transform.position.z>=_cameraMinZ)
           {
               _speed += 0.1f;
               transform.Translate(Vector3.right * Time.deltaTime * _speed);
           }
       }

       else if (Input.GetKeyUp(KeyCode.D))
       {
           _speed = 1;
       }

       _camera.fieldOfView += Input.mouseScrollDelta.y;
       //_zoomLevel += Input.mouseScrollDelta.y * _sensitivity; //zoom position is a float//all are floats
      // _zoomLevel = Mathf.Clamp(_zoomLevel, 0, _maximumZoom);
      // _zoomPosition = Mathf.MoveTowards(_zoomPosition, _zoomLevel, _speed * Time.deltaTime);
      // transform.position += transform.forward * _zoomLevel;


       //_zoomLevel += Input.mouseScrollDelta.y;
       //transform.position += transform.forward *_zoomLevel;
      // Input.mouseScrollDelta.y += _camera.fieldOfView;
       //else if (Input.mouseScrollDelta.y)


     // _zoomLevel += _input.Player.ScrollWheel.ReadValue<float>() * _sensitivity;//
        //_zoomLevel += Mathf.Clamp(_zoomLevel, 0, _maximumZoom);
        //_zoomPosition = Mathf.MoveTowards(_zoomPosition, _zoomLevel, _speed* Time.deltaTime);
       // transform.position = transform.forward * _zoomLevel;

      //  _camera.fieldOfView += Input.mouseScrollDelta.y;
       // _zoomLevel += Input.mouseScrollDelta.y * _sensitivity; //zoom position is a float//all are floats
      // _zoomLevel = Mathf.Clamp(_zoomLevel, 0, _maximumZoom);
    //   _zoomPosition = Mathf.MoveTowards(_zoomPosition, _zoomLevel, _speed * Time.deltaTime);
       // transform.position += transform.forward * _zoomLevel;


        //_zoomLevel += Input.mouseScrollDelta.y;
        //transform.position += transform.forward *_zoomLevel;
       // Input.mouseScrollDelta.y += _camera.fieldOfView;
        //else if (Input.mouseScrollDelta.y)

    //this is from enemy 
     //may have to include logic if there are no towers.
       // foreach (var obj in GameObject.FindGameObjectsWithTag("Tower"))
       // {
            //is only caring about the first tower and nothing else
            //try using colliders this will allow you to grab the reference to it and than attack it specifically
            //this is because var nearestEnemy = GetComponenet<Tower>().towers[0];is singular not plural like the below
           // var nearestEnemy = GameObject.FindGameObjectWithTag("Tower");
            //var nearestEnemy = GameObject.FindGameObjectsWithTag("Tower")[0];
            //if (Vector3.Distance(obj.transform.position, transform.position) < Vector3.Distance(nearestEnemy.transform.position, transform.position))
           // {
          //      nearestEnemy = obj;
           // }
            

           // float dist = Vector3.Distance(nearestEnemy.transform.position, transform.position);

            /*if (dist < 5)
            {
                nearestEnemy.GetComponent<Tower>().Damage(); //changing it to nearestEnemy made it work better rather than obj.
                _leftMuzzleFlash.SetActive(true);
                _rightMuzzleFlash.SetActive(true);
                if (_startWeaponNoise == true) //checking if we need to start the gun sound
                {
                    _audioSource.Play(); //play audio clip attached to audio source
                    _startWeaponNoise = false; //set the start weapon noise value to false to prevent calling it again
                }
                Vector3 directionToFace = obj.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(directionToFace);            
            }*/
    // else if (dist > 5)
    //{
    //_leftMuzzleFlash.SetActive(false);
    // _rightMuzzleFlash.SetActive(false);
    //_startWeaponNoise = true;
    //_audioSource.Stop();
    //   }


    //   }

    //this is from dual gatling gun
    /*
          if (Input.GetMouseButton(0)) //Check for left click (held) user input
          { 
              RotateBarrel(); //Call the rotation function responsible for rotating our gun barrel

              //for loop to iterate through all muzzle flash objects
              for(int i = 0; i < _muzzleFlash.Length; i++)
              {
                  _muzzleFlash[i].SetActive(true); //enable muzzle effect particle effect
                  _bulletCasings[i].Emit(1); //Emit the bullet casing particle effect   
              }

              if (_startWeaponNoise == true) //checking if we need to start the gun sound
              {
                  _audioSource.Play(); //play audio clip attached to audio source
                  _startWeaponNoise = false; //set the start weapon noise value to false to prevent calling it again
              }

          }
          else if (Input.GetMouseButtonUp(0)) //Check for left click (release) user input
          {
              //for loop to iterate through all muzzle flash objects
              for (int i = 0; i < _muzzleFlash.Length; i++)
              {
                  _muzzleFlash[i].SetActive(false); //enable muzzle effect particle effect
              }
              _audioSource.Stop(); //stop the sound effect from playing
              _startWeaponNoise = true; //set the start weapon noise value to true
          }*/



    //this is from spawnmanager
    /* private IEnumerator StartWave()
   {
       while (true)
       {
           switch (_currentWave)
           {
               case 0:
                   RequestMech();
           break;


           }

           var currentWave = _waves[_currentWave].sequence;
           var previousWave = new GameObject("PreviousWave");

           foreach (var obj in currentWave)
           {
               Instantiate(obj, previousWave.transform);
               yield return new WaitForSeconds(5);
           }
           yield return new WaitForSeconds(5);
           Destroy(previousWave);

           _currentWave++;
           if (_currentWave == _waves.Count)
           {
               Debug.Log("Finished waves");
               break;
           }
       }



       //RequestMech();



   }
   /* private IEnumerator StartWaveSequence()
    {
        while (true)
        {
            //if (_allActive==true)
            if()
            {
                yield return new WaitForSeconds(10);
                _allActive = false;
                _currentWave++;
                _mechs = MechGenerator(_waves[_currentWave].sequence.Count);
                //break;
            }
            else if (_allActive==false)
            {
                yield return new WaitForSeconds(5);
                RequestMech();
            }


        }



     //need to call request mech probably here
        /* while (true)
        {
            var currentWave = _waves[_currentWave].sequence;
            var previousWave = new GameObject("PreviousWave");
            foreach(var obj in currentWave)
            {
                Instantiate(obj,previousWave.transform);
                yield return new WaitForSeconds(10);
            }
            yield return new WaitForSeconds(5);
            Destroy(previousWave);

            if (_currentWave==_waves.Count)
            {

            }
            break;
        }
        */

    // }

    // if (_mechs.All(m => m.gameObject.activeInHierarchy == true))
    //{
    //  return null;
    //}
    //you could increment mechs by ++ and than break the loop that way.
    // if (_mechs.All(m => m.gameObject.activeInHierarchy == true))//by doing this we can only go to the next wave by destroying all mechs
    //just need to create a list to deactivate one by one and when they are all false we can go to next wave
    //just fufill requirements you don't have to use it.
    //if need be create another list 
    //more likely you will need to create a timer that will end all mechs
    //do the easier thing 
    //when a mech dies just recycle it
    //  {

    //      Destroy(previousWave);
    //   }

}
