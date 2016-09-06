using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BallMove : MonoBehaviour 
{
	// Magical Dot operator .
	//Dot operator allow you to get or look at a variable inside of an object
    public int dirx;
    public float speed = 1;
    public int diry;
    int collisionCounter = 0;
    int[] xBoundries = new int[] { -13, 13 };
    int[] yBoundries = new int[] { -8, 8 };
    public System.DateTime lifeBegins;
    public int racketSpeed = 20;
    public int p1Score = 0;
    public int p2Score = 0;
    public TextMesh rightTextbox;
    public TextMesh leftTextbox;
    public TextMesh fastestPlay;
    public TextMesh recordTextbox;
    public TextMesh scoreOne;
    public TextMesh scoreTwo;
//    public TextMesh fastestRecord;
    int infinity = 999999;
    int p1MinTime;
    int p2MinTime;
    static int minTime = 999999;
    public System.DateTime start;
    public bool gameFinish;
    public int highestScoreToWin = 5;

    // Use this for initialization
    void Start () 
	{
        //        transform.position = new Vector3(Random.Range(-1, 1),
        //            Random.Range(-1, 1), 0);
        p1Score = 0;
        p2Score = 0;
        if (minTime < infinity)
        {
            fastestPlay.text = "Fastest play " + minTime + " secs";
        } else
        {
            fastestPlay.text = "";
        }

        rightTextbox.text = "";
        leftTextbox.text = "";
        gameFinish = false;
        scoreOne.text = "";
        scoreTwo.text = "";
//        fastestRecord.text = "";
        start = System.DateTime.Now;
        p1MinTime = p2MinTime = infinity;
        lifeBegins = System.DateTime.Now;
        int[] directions = new int[] { -1, 1 };
        dirx = directions[Random.Range(0, directions.Length)];
        diry = directions[Random.Range(0, directions.Length)];
        transform.position = new Vector3(Random.Range(xBoundries[0], xBoundries[1]),
            Random.Range(yBoundries[0], yBoundries[1]), 0);
        recordTextbox.text = "";
	}
    //When two cubes collide and their movement
    void OnCollisionEnter(Collision col)
    {
        collisionCounter++;
        /*        if(collisionCounter == 5)
                {
                    speed = Random.Range(1, 20) / 10.0f;
                }
        */
        if (!gameFinish)
        {
//            fastestRecord.text = "Fastest Time:" + minTime;
            if (col.gameObject.name.StartsWith("top"))
            {
                diry = -1;
                speed++;
                transform.Translate(new Vector3(dirx * speed, diry * speed, 0) * Time.deltaTime);
            }
            else if (col.gameObject.name.StartsWith("bottom"))
            {
                diry = +1;
                speed++;
                transform.Translate(new Vector3(dirx * speed, diry * speed, 0) * Time.deltaTime);
            }
            else if (col.gameObject.name.StartsWith("left"))
            {
                speed++;
                dirx = +1;
                transform.Translate(new Vector3(dirx * speed, diry * speed, 0) * Time.deltaTime);
            }
            else if (col.gameObject.name.StartsWith("right"))
            {
                dirx = -1;
                speed++;
                transform.Translate(new Vector3(dirx * speed, diry * speed, 0) * Time.deltaTime);
            }
        }
    }



    // Update is called once per frame
    void Update () 
	{
        int secondsSinceGameBegan = System.DateTime.Now.Subtract(start).Seconds;
        scoreOne.text = "" + p1Score.ToString();
        scoreTwo.text = "" + p2Score.ToString();
        //Code jumps below the body of the 'if' is condition is false
        //Check is the ball went too high in space
        //I combined both conditions
        if (!gameFinish)
        {
            if (transform.position.y > 10 ||
                transform.position.y < -10)
            {
                //Three ways to reverse it: 

                diry = -1 * diry;
            }

            /*To get the Ball bounce between left and right walls

                    if (transform.position.x > 15 || 
                        transform.position.x < -15) 
                    {
                        dirx = -1 * dirx;
                        reverseXCount++;
                        print(string.Format("reversing x for {0} for {1} times", 
                            name, reverseXCount));
                    }
            */

            if (transform.position.x > 15.2 && p2Score < 5)
            {
                p2Score++;
                print(string.Format("P2 score is {0}:", p2Score));
                gameObject.transform.position = new Vector3(0, 0, 0);
                // Destroy(gameObject);
            }
            else if (transform.position.x < -15.2 && p1Score < 5)
            {
                p1Score++;
                print(string.Format("P1 score is {0}:", p1Score));
               gameObject.transform.position = new Vector3(0, 0, 0);
            }
        }
        bool p1Won = p1Score == highestScoreToWin && p1Score > p2Score;
        bool p2Won = p2Score == highestScoreToWin && p2Score > p1Score;
    
        if (p1Won) 
        {
            print("Player 1 is the winner");
            if (secondsSinceGameBegan < p1MinTime)
            {
                p1MinTime = secondsSinceGameBegan;
                print("setting new record");
            }
            if (p1MinTime < minTime)
            {
                minTime = p1MinTime;
                recordTextbox.text = "Player 1 won set record to " + minTime + " secs";
            }
            rightTextbox.text = "Player 1 won";
            rightTextbox.color = Color.cyan;
            leftTextbox.text = "Press 'R' to Restart";
            rightTextbox.color = Color.green;
        }
        if (p2Won)
        {
            leftTextbox.text = "Player 2 won";
            leftTextbox.color = Color.cyan;
            rightTextbox.text = "Press 'R' to Restart";
            rightTextbox.color = Color.green;
            print("Player 2 is the winner");
            if (secondsSinceGameBegan < p2MinTime)
            {
                p2MinTime = secondsSinceGameBegan;
            }
            if (p2MinTime < minTime)
            {
                minTime = p2MinTime;
                recordTextbox.text = "Player 2 won set record to " + minTime + " secs";
            }
        }

        if (p1Won || p2Won)
        {
            gameFinish = true;
        }
        else
        {
            transform.Translate(new Vector3(dirx * speed, diry * speed, 0) * Time.deltaTime);
        }
        if (gameFinish)
        {
            if (Input.GetButtonDown("Restart") || Input.GetButtonUp("Restart"))
            {
                p1Score = 0;
                p2Score = 0;
                //Loads a level
                Application.LoadLevel("Pong_Faranak");
            }
        }
    }
}