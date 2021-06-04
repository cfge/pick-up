using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headControllerPart1 : MonoBehaviour
{
    float xRotate;
    float yRotate;
    float sens = 3f;
    public GameObject window;
    public GameObject bottle;
    public GameObject hand;
    RaycastHit hit_object;
   

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
     
        window.SetActive(false);
        xRotate = xRotate - Input.GetAxis("Mouse Y") * sens;
        yRotate = yRotate + Input.GetAxis("Mouse X") * sens;
        xRotate = Mathf.Clamp(xRotate, -90, 90);
        transform.rotation = Quaternion.Euler(xRotate, yRotate, 0);
        FindObjectOfType<BodyController>().SomeMethod(yRotate);
        Debug.DrawRay(transform.position, transform.forward*3f, Color.red);

        if(Input.GetKeyDown("e"))
                    {
                     bottle.transform.SetParent(null);   
                    }
        if(Physics.Raycast(transform.position, transform.forward,out hit_object,3f))
        {
                if(hit_object.collider.gameObject.tag=="Bottle"){
                    window.SetActive(true);
                    if(Input.GetKeyDown("e"))
                    {
                        bottle.transform.position = hand.transform.position;
                        bottle.transform.SetParent(hand.transform);
                    }
            }
        }
        
    }
}
