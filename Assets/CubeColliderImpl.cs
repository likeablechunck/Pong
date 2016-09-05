using UnityEngine;
using System.Collections;

public class CubeColliderImpl : MonoBehaviour {

    // Use this for initialization
    void OnCollisionEnter(Collision col)
    {
        print("yoyo");
        string myself = name;
        if (col.gameObject.name != myself && col.gameObject.name.StartsWith("Cube"))
        {
            Vector3 selfPosition = transform.position;
            Vector3 selfDimension = transform.localScale;
            Vector3 otherDimension = col.gameObject.transform.localScale;
            Vector3 otherPosition = col.gameObject.transform.position;
            bool selfOnTop = (selfPosition.y - selfDimension.y / 2) ==
                (otherPosition.y + otherDimension.y / 2);
            bool selfOnBottom = (selfPosition.y + selfDimension.y / 2) ==
                (otherPosition.y - otherDimension.y / 2);
            bool selfOnLeft = (selfPosition.x + selfDimension.x / 2) ==
                (otherPosition.x - otherDimension.x / 2);
            bool selfOnRight = (selfPosition.x - selfDimension.x / 2) ==
                (otherPosition.x + otherDimension.x / 2);
            System.Console.Write(" bools : %s %s %s %s", selfOnTop, selfOnBottom, selfOnLeft, selfOnRight);

            if (selfOnTop)
            {
                selfPosition.y -= 1;
                otherPosition.y += 1;

            }
            else if (selfOnBottom)

            {
                selfPosition.y -= 1;
                otherPosition.y += 1;

            }
            else if (selfOnLeft)
            {
                selfPosition.x -= 1;
                otherPosition.x += 1;
            }
            else if (selfOnRight)
            {
                selfPosition.x += 1;
                otherPosition.x -= 1;
            }
            else if (selfOnLeft && selfOnTop)
            {
                selfPosition.x -= 1;
                selfPosition.y += 1;
                otherPosition.x += 1;
                otherPosition.y -= 1;

            }
            else if (selfOnBottom && selfOnRight)
            {
                selfPosition.x += 1;
                selfPosition.y -= 1;
                otherPosition.x -= 1;
                otherPosition.y += 1;
            }
            else if (selfOnTop && selfOnRight)
            {
                selfPosition.x += 1;
                selfPosition.y += 1;
                otherPosition.x -= 1;
                otherPosition.y -= 1;
            }
            else if (selfOnLeft && selfOnBottom)
            {
                selfPosition.x -= 1;
                selfPosition.y -= 1;
                otherPosition.x += 1;
                otherPosition.y += 1;
            }
        }
    }
}
