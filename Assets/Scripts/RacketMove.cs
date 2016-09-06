using UnityEngine;
using System.Collections;

public class RacketMove : MonoBehaviour
{
    public float RacketSpeed = 20;
    public string axis = "Vertical";
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float v = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody>().velocity = new Vector3(0, v, 0) * RacketSpeed;

    }
}
