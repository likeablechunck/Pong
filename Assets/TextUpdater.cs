using UnityEngine;
using System.Collections;

public class TextUpdater : MonoBehaviour {

    public TextMesh timeText;
    public System.DateTime start;

	// Use this for initialization
	void Start () {
        start = System.DateTime.Now;
        timeText.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("cube1") != null &&
            GameObject.Find("cube2") != null &&
            GameObject.Find("cube3") != null &&
            GameObject.Find("cube4") != null)
            timeText.text = System.DateTime.Now.Subtract(start).TotalSeconds.ToString();
    }
}
