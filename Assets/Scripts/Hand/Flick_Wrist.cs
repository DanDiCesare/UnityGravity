using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
 
 public class Flick_Wrist : MonoBehaviour {
    Animator anim;
    public StressReceiver m_someOtherScriptOnAnotherGameObject;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Active");
            m_someOtherScriptOnAnotherGameObject = GameObject.FindObjectOfType(typeof(StressReceiver)) as StressReceiver;
            m_someOtherScriptOnAnotherGameObject.InduceStress(0.2f);
            //anim.ResetTrigger("Active");
        }
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("Pulling");
            m_someOtherScriptOnAnotherGameObject = GameObject.FindObjectOfType(typeof(StressReceiver)) as StressReceiver;
            m_someOtherScriptOnAnotherGameObject.InduceStress(0.2f);
            //anim.ResetTrigger("Active");
        }
    }
 }