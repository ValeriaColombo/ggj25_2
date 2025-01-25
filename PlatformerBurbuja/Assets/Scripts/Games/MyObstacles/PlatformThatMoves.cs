using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformThatMoves : MonoBehaviour
{
    [SerializeField] Transform platform;
    [SerializeField] Vector2[] travelPoints;
    [SerializeField] bool oneDirOnly;
    [SerializeField] float speed;

    private void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        int currentPoint = 0;
        int direction = 1;

        platform.localPosition = travelPoints[currentPoint];

        var asd = 0.05f;

        int nextPoint;
        while (true)
        {
            nextPoint = GetNextTravelPoint(currentPoint, ref direction);
            Vector2 destination = travelPoints[nextPoint];

            float distanceX = platform.localPosition.x - destination.x;
            float distanceY = platform.localPosition.y - destination.y;
            while (Math.Abs(distanceX) >= asd || Math.Abs(distanceY) >= asd)
            {
                var speedX = Math.Abs(distanceX) < asd ? 0 : speed * Time.fixedDeltaTime * (distanceX > 0 ? -1 : 1);
                var speedY = Math.Abs(distanceY) < asd ? 0 : speed * Time.fixedDeltaTime * (distanceY > 0 ? -1 : 1);
                platform.Translate(speedX, speedY, 0);
                
                yield return new WaitForEndOfFrame();
                distanceX = platform.localPosition.x - destination.x;
                distanceY = platform.localPosition.y - destination.y;
            }
            currentPoint = nextPoint;
            platform.localPosition = travelPoints[currentPoint];
            yield return new WaitForEndOfFrame();
        }
    }

    private int GetNextTravelPoint(int currentPoint, ref int direction)
    {
        int nextPoint = currentPoint + direction;
        if (nextPoint < 0)
        {
            direction = 1;
            nextPoint = 1;
        }
        else if (nextPoint >= travelPoints.Length)
        {
            if (oneDirOnly)
            {
                nextPoint = 0;
            }
            else
            {
                direction = -1;
                nextPoint = currentPoint - 1;
            }
        }

        return nextPoint;
    }
}
