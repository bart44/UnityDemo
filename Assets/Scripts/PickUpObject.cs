using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour {

    CounterController counterController;
    
	// Use this for initialization
	void Start () {
        counterController = GameObject.Find("ScriptManager").GetComponent<CounterController>();
        if(counterController == null)
        {
            Debug.LogError("counterController nie został znaleziony");
        }
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Zombie")
        {
            counterController.IncrementCounter();
            Destroy(this.gameObject);
        }
    }
}
