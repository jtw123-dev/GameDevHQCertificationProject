using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _cameraMinY,_cameraMaxY,_cameraMinZ,_cameraMaxZ;
    [SerializeField] private Camera _camera;
    [SerializeField] private  float _zoomLevel;
    [SerializeField] private float _sensitivity;
    private float _zoomPosition;
    [SerializeField] private float _maximumZoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {     
        if (Input.GetKey(KeyCode.W))
        {        
            if (transform.position.y<=_cameraMaxY)

            {
                _speed += 0.1f;
                transform.Translate(Vector3.up * Time.deltaTime * _speed);
            }         
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            _speed = 1;
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
    
}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Boundary")
        {
           //try restricting via code instead
            
        }
    }
}
