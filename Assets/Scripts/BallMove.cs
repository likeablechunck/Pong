using UnityEngine;


public class BallMove : MonoBehaviour 
{
	// Magical Dot operator .
	//Dot operator allow you to get or look at a variable inside of an object
    public int dirx;
    public float speed = 1;
    public int diry;
    int reverseYCount = 0;
    int reverseXCount = 0;
    int collisionCounter = 0;
    int[] xBoundries = new int[] { -13, 13 };
    int[] yBoundries = new int[] { -8, 8 };
    public System.DateTime lifeBegins;
    

    // Use this for initialization
    void Start () 
	{
        //        transform.position = new Vector3(Random.Range(-1, 1),
        //            Random.Range(-1, 1), 0);
        lifeBegins = System.DateTime.Now;
        int[] directions = new int[] { -1, 1 };
        dirx = directions[Random.Range(0, directions.Length)];
        diry = directions[Random.Range(0, directions.Length)];
        speed = Random.Range(1, 20) / 10.0f;
        transform.position = new Vector3(Random.Range(xBoundries[0], xBoundries[1]),
            Random.Range(yBoundries[0], yBoundries[1]), 0);
        reverseXCount = 0;
        reverseYCount = 0;
		//Everything has a transform
		//we can use the dot operator to look at the position
		//transform.position
	}
    //When two cubes collide and their movement
    void OnCollisionEnter(Collision col)
    {
        collisionCounter++;
        if(collisionCounter == 5)
        {
            speed = Random.Range(1, 20) / 10.0f;
        }
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
        } else if(col.gameObject.name.StartsWith("cube"))
        {
            Destroy(gameObject);
        }
        return;
    }



    // Update is called once per frame
    void Update () 
	{
		//Code jumps below the body of the 'if' is condition is false

		//Check is the ball went too high in space

		//I combined both conditions
        
        if (transform.position.y > 10 ||
            transform.position.y < -10)
		{
            //Three ways to reverse it: 
            
            diry = -1 * diry;
            reverseYCount++;
            print(string.Format("reversing y for {0} for {1} times",
                name, reverseYCount));
            print(transform.position);
        }

		//To get the Ball bounce between left and right walls

		if (transform.position.x > 15 || 
            transform.position.x < -15) 
		{
            dirx = -1 * dirx;
            reverseXCount++;
            print(string.Format("reversing x for {0} for {1} times", 
                name, reverseXCount));
        }
        //transform.position = transform.position + direction;
        transform.Translate(new Vector3(dirx * speed, diry* speed, 0) * Time.deltaTime);
    }
}