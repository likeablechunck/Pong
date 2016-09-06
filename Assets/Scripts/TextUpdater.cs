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
        if (GameObject.Find("cube1") && GameObject.Find("cube1").GetComponent<BallMove>())
        {
            BallMove bv = GameObject.Find("cube1").GetComponent<BallMove>();
            if (!bv.gameFinish)
            {
                timeText.text = string.Format("{0:0.00}", System.DateTime.Now.Subtract(start).TotalSeconds);
            }
        }
    }
}
