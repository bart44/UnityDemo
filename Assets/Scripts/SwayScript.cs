using UnityEngine;
using System.Collections;

public class SwayScript : MonoBehaviour
{
    public float speed;
    public float maxRotation;

    void Update()
    {
        //transform.rotation = Quaternion.Euler(0.0f, 0.0f, maxRotation * Mathf.Sin(Time.time * speed)); // wyprobuj to ...
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, maxRotation * (Mathf.PingPong(Time.time * speed, 2.0f)-1.0f)); // ... lub to
    }

}