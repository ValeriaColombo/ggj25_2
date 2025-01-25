using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingFire : MonoBehaviour
{
    [SerializeField] private Transform fireball;
    [SerializeField] private SpriteRenderer fireballSprite;
    [SerializeField] private float horSpeed = 0.5f;
    [SerializeField] private float minX = -3;
    [SerializeField] private float maxX = 3;

    [SerializeField] private int direction = 1;

    void Update()
    {
        fireball.transform.Translate(direction * horSpeed * Time.fixedDeltaTime, 0, 0);

        fireballSprite.flipY = direction > 0;

        if (direction > 0 && fireball.transform.localPosition.x > maxX)
            direction = -1;
        else if (direction < 0 && fireball.transform.localPosition.x < minX)
            direction = 1;
    }
}
