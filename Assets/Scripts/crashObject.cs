using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crashObject : MonoBehaviour {

    float crash = 0;

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            transform.rotation = Quaternion.Euler(crash, crash, crash);
        }
    }
}
