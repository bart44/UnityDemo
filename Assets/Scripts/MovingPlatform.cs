using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public Transform sceneStartPoint;
    public Transform sceneEndPoint;
    public float speed;
   
    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 currentPlatformPosition;

	// Use this for initialization
	void Start () {
        startPoint = sceneStartPoint.position;
        endPoint = sceneEndPoint.position;
        Destroy(sceneStartPoint.gameObject);
        Destroy(sceneEndPoint.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        currentPlatformPosition = Vector2.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time * speed, 1));
        transform.position = currentPlatformPosition;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log(other.gameObject.name);
            other.transform.parent = transform; //podpinam postac do prefabu z colliderem, zeby poruszal sie razem z nim
            other.attachedRigidbody.Sleep();
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log(other.gameObject.name + " out");
            other.transform.parent = null; // odpinam parenta i postac wraca do hierarchii bez parenta
        }
            
    }
}
