using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterController : MonoBehaviour {

    double numberOfObjects;
    public Text counterView;

	// Use this for initialization
	void Start () {
        ResetCounter();
    }
	
    public void IncrementCounter()
    {
        numberOfObjects = (numberOfObjects + 1) - 0.5;
        counterView.text = numberOfObjects.ToString();
    }

    public void ResetCounter()
    {
        numberOfObjects = 0;
        counterView.text = numberOfObjects.ToString();
    }
}
