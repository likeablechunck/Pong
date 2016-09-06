using UnityEngine;
using System;

public class Story : MonoBehaviour
{
    float b1speed = 0;
    float b2speed = 0;
    float b3speed = 0;
    float b4speed = 0;
    System.DateTime b1Life;
    System.DateTime b2Life;
    System.DateTime b3Life;
    System.DateTime b4Life;
    bool b1Dead = true;
    bool b2Dead = true;
    bool b3Dead = true;
    bool b4Dead = true;


    // Use this for initialization
    void Start ()
    {
        string Name = "Faranak";
        string Location = "San Francisco";
        string theTime = System.DateTime.Now.ToString("hh:mm:ss tt");
        string theDate = System.DateTime.Now.ToString("MM/dd/yyyy");
        print(string.Format("it's {0} and the date is {1}", theTime, theDate));
        //string theMonth = System.DateTime.Now.Month();
        print("Hello");
        print(string.Format("My name is {0}.I Live in {1}", Name, Location));
        //Getting inout from the user
        //        string UserName = Input.inputString;
        //print(UserName);
    }

    // Update is called once per frame
    void Update()
    {
        // tell the story about each ball and how fast they are cruising right now
        if (GameObject.Find("cube1") != null)
        {
            b1Dead = false;
            b1Life = GameObject.Find("cube1").GetComponent<BallMove>().lifeBegins;
            float currentB1Speed = GameObject.Find("cube1").GetComponent<BallMove>().speed;
            if (currentB1Speed != b1speed)
            {
                b1speed = currentB1Speed;
                print(string.Format("cube1 Cruising At Speed : {0}", b1speed));
            }
        } else if (!b1Dead)
        {
            print(string.Format("cube1 is down! after serving for {0} seconds",
                DeltaInTotalSeconds(b1Life)));
            b1Dead = true;
        }
        if(GameObject.Find("cube2") != null) {
            b2Dead = false;
            float currentB2Speed = GameObject.Find("cube2").GetComponent<BallMove>().speed;
            if (currentB2Speed != b2speed)
            {
                b2Life = GameObject.Find("cube2").GetComponent<BallMove>().lifeBegins;
                b2speed = currentB2Speed;
                print(string.Format("cube2 Cruising At Speed : {0}", b2speed));
            }
        } else if (!b2Dead)
        {
            print(string.Format("cube2 is down! after serving for {0} seconds",
                DeltaInTotalSeconds(b2Life)));
            b2Dead = true;
        }
        if (GameObject.Find("cube3") != null)
        {
            b3Dead = false;
            float currentB3Speed = GameObject.Find("cube3").GetComponent<BallMove>().speed;
            b3Life = GameObject.Find("cube3").GetComponent<BallMove>().lifeBegins;
            if (currentB3Speed != b3speed)
            {
                b3speed = currentB3Speed;
                print(string.Format("cube3 Cruising At Speed : {0}", b3speed));
            }
        }
        else if (!b3Dead)
        {
            print(string.Format("cube3 is down! after serving for {0} seconds",
                DeltaInTotalSeconds(b3Life)));
            b3Dead = true;
        }
        if (GameObject.Find("cube4") != null)
        {
            b4Dead = false;
            float currentB4Speed = GameObject.Find("cube4").GetComponent<BallMove>().speed;
            b4Life = GameObject.Find("cube4").GetComponent<BallMove>().lifeBegins;
            if (currentB4Speed != b4speed)
            {
                b4speed = currentB4Speed;
                print(string.Format("cube4 Cruising At Speed : {0}", b3speed));
            }
        }
         else if (!b4Dead)
        {
            print(string.Format("cube4 is down! after serving for {0} seconds", 
                DeltaInTotalSeconds(b4Life)));
            b4Dead = true;
        }
    }

    TimeSpan DeltaInTotalSeconds(System.DateTime since)
    {
        return System.DateTime.Now.Subtract(since);
    }
}
