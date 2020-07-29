using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull_In : MonoBehaviour
{
    public GameObject attractedTo;
    public float strengthOfAttraction = 5.0f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(1)) //Pull towards
        {
            Vector3 direction = attractedTo.transform.position - transform.position;
            float strength = strengthOfAttraction - direction.magnitude + 5;
            if (strength < 0)
                strength = 0;
            gameObject.GetComponent<Rigidbody>().AddForce (strength * direction);
        }

        if (Input.GetMouseButton(0)) //Push away
        {
            Vector3 direction = attractedTo.transform.position - transform.position;
            float strength = strengthOfAttraction - direction.magnitude + 5;
            if (strength < 0)
                strength = 0;
            gameObject.GetComponent<Rigidbody>().AddForce (strength * direction * -4 );
        }
        
    }
}
