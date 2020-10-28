using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int planeIndicator = 0;

    float speed = 10.0f;
    float PlaneALimit = 9.9f;
    float PlaneBLimit = 4.9f;

    float relzLimit;
    float relxLimit;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (planeIndicator == 0)
        {
            relzLimit = PlaneALimit;
            relxLimit = PlaneALimit;

            if(transform.position.z > relzLimit)
            {
                if (transform.position.x > -relzLimit / 2 && transform.position.x < relxLimit / 2)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, relzLimit);
                }
            }
            else if(transform.position.z < - relzLimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -relzLimit);
            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
            }

            if (transform.position.x > relxLimit)
            {
                transform.position = new Vector3(relxLimit, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -relxLimit)
            {
                transform.position = new Vector3(-relxLimit, transform.position.y, transform.position.z);
            }
            else
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
            }
        }
        else
        {
            relzLimit = PlaneALimit + 2 * PlaneBLimit;
            relxLimit = PlaneBLimit;

            if(transform.position.z < PlaneALimit)
            {
                if (transform.position.x > -PlaneALimit / 2 && transform.position.x < PlaneALimit / 2)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, PlaneALimit);
                }
            }
            else if (transform.position.z > relzLimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, relzLimit);
            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
            }

            if (transform.position.x > relxLimit)
            {
                transform.position = new Vector3(relxLimit, transform.position.y, transform.position.z);
            }
            else if(transform.position.x < -relxLimit)
            {
                transform.position = new Vector3(-relxLimit, transform.position.y, transform.position.z);
            }
            else
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
            }
        }
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlaneA")
        {
            Debug.Log("In Plane A");
            planeIndicator = 0;
        }

        if (collision.gameObject.name == "PlaneB")
        {
            Debug.Log("In Plane B");
            planeIndicator = 1;
        }
    }
}
