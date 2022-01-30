using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.TextCore;

public class KeyActivator : MonoBehaviour
{
    // Start is called before the first frame update
    private bool state = false;
    public int counter;
    void Start()
    {
        this.gameObject.SetActive(state);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            state = !state;
            this.gameObject.SetActive(state);
            counter++;
        }
    }
}
