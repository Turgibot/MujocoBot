using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MujocoCam : MonoBehaviour
{
    public Transform Len;
    private Transform site;
    void Start()
    {
        site = this.gameObject.transform;
        site.SetParent(Len);
        site.localPosition = Vector3.zero;
        site.localRotation = Quaternion.Euler(new Vector3(0,270, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
