using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FollowingHero : MonoBehaviour {

    public GameObject hero;
    public float smooth;
    private Vector3 currentVelocity;
    float lockPos = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
        Vector3 newCameraPosition = new Vector3(hero.transform.position.x, hero.transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, newCameraPosition, ref currentVelocity, smooth);      
	}
}
