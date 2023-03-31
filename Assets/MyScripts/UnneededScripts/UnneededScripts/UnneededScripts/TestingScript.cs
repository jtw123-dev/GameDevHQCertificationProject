using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 
    /* RaycastHit hitInfo;
     Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);

     if (Input.GetMouseButton(0))
     {
         if(Physics.Raycast(rayOrigin,out hitInfo))
         {
             Debug.Log(hitInfo.collider.name);
             hitInfo.collider.transform.position = hitInfo.point;
              //hitInfo.collider.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, -Camera.main.nearClipPlane));
             //_selectedObj = hitInfo.transform.gameObject;
         }
     }


 */

}

    private Vector3 screenPoint;
    private Vector3 offset;
    Vector3 cursorPosition;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
         cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }

    
   
   /* private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z );

        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 offset = objPosition;
        transform.position = objPosition-offset;

       

    }
    */
    private void OnMouseUp()
    {
       
    }
}
