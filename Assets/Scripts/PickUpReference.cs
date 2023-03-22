using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpReference : MonoBehaviour
{
    public Transform targetObj;
    public Transform referencePt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        referencePt.transform.position = targetObj.transform.position + new Vector3(0,0,5);
    }
}
