using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BreakGravity : MonoBehaviour
{
    //For rotation
    private bool rotRight = false;
    private bool rotLeft = false;
    private float rotX = 0;
    private float rotY = 0;
    private float rotZ = 0;
    private Rigidbody rb;
    public RigidbodyFirstPersonController fpc;


    // Start is called before the first frame update
    void Start()
    {
        fpc = GameObject.FindObjectOfType<RigidbodyFirstPersonController>();
        rb = fpc.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void saveView() {
        rotX = fpc.transform.rotation.eulerAngles.x;
        rotY = fpc.transform.rotation.eulerAngles.y;
        rotZ = fpc.transform.rotation.eulerAngles.z;
        print("saved view");
    }

    private void loadView() {
        fpc.transform.Rotate(rotX, rotY, rotZ, Space.Self);
        print("reset");
    }

    private void artificialGravity() {
            rb.AddRelativeForce(Vector3.down * 9.81f, ForceMode.Acceleration);
    }

    private void rotateBody(bool left) {
        if (left) {
            fpc.transform.Rotate(-90, 0, 0, Space.Self);
        }
        else {
            fpc.transform.Rotate(-90, 0, 0, Space.Self);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            loadView();
        }

        //Check inputs
        if(Input.GetKeyDown(KeyCode.Q) && !rotLeft)
            {
                
                //reset camera
                
                if (rotRight) { //return from right
                    loadView();
                    rotateBody(false);
                    rotRight = false;
                    
                } else { //rotate left
                    rotateBody(true);
                    rotLeft = true;
                    saveView();
                }
                Debug.Log("Here pressed");
                
            }
        if(Input.GetKeyDown(KeyCode.E) && !rotRight)
            {
                //reset camera
                
                if (rotLeft) { //return from left
                    loadView();
                    rotateBody(false);
                    rotLeft = false;
                } else { //rotate right
                    rotateBody(true);
                    rotRight = true;
                    saveView();
                }
            }
    }

    void FixedUpdate() {
        //Check for artificial gravity
        artificialGravity();
    }
}
