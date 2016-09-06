using UnityEngine;
using System.Collections;
// comments are ignored by unity
//meant to be used to leave notes and description

/* THIS IS A BLOCK COMMENT
 * it ends w
 *ith
 * */
/*
 * Body of Code:
 * Anything inside the {}
 * every { needs a }
 * every ( needs a )
 * */

public class HelloWorld : MonoBehaviour 
{
	//On Event Begin Play
	// Use this for initialization
	void Start () 
	{
		print ("Hello Hello World"); 
	}

	//On Event Tick
	// Update is called once per frame
	void Update () 
	{
	
		print ("Spam!");
	}
}
