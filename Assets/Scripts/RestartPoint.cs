using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPoint : MonoBehaviour {

    RestartPointsManager restartPointsManager;
    SpriteRenderer sprRenderer;
    BoxCollider2D removeCollider;


    // Use this for initialization
    void Start () {

        restartPointsManager = GameObject.Find("ScriptManager").GetComponent<RestartPointsManager>();
        if(restartPointsManager == null)
        {
            Debug.LogError("Zjebal sie restart point manager...");
        }
        sprRenderer = GetComponent<SpriteRenderer>();

        removeCollider = GameObject.Find("StartPoint").GetComponent<BoxCollider2D>();
    }
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if( other.gameObject.tag == "Player")
        {
            restartPointsManager.UpdateStartPoint(this.gameObject.transform);
            sprRenderer.color = new Color(0.3f, 0.6f, 0.6f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            removeCollider.enabled = false;
        }
    }
}


