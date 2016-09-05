using UnityEngine;
using System.Collections;

public class Variables : MonoBehaviour 
{
	//Declaring Variables
	//(protection optional) type name
	// Use this for initialization

	public int MyAge;
	public bool IsAlive = true;

	void Start () 
	{
		print (MyAge);
		//modifying values:
		//= Assignment operator
		//variables on the left side  = is changed to whatever is on the right side
		MyAge = 40;

		//this doesn't do anything
		MyAge = MyAge + 1;

		//descriptive print statement
		print ("Billy is currently\t" + MyAge + "\tYears old\n");
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
