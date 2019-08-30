using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockHeroZ : MonoBehaviour {

    float lockHeroPos = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockHeroPos, lockHeroPos);
    }
}
