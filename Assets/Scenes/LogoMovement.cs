using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LogoMovement : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    SpriteRenderer spriteRenderer;
    Vector3 screenBounds;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        direction = new Vector3(1, 1, 0);
        transform.position = Random.insideUnitCircle * 3;
    }

    void Update()
    {
        var nextPosition = transform.position + direction * speed * Time.deltaTime;

        var minXPoint = -screenBounds.x + spriteRenderer.bounds.extents.x;
        var maxXPoint = screenBounds.x - spriteRenderer.bounds.extents.x;

        var minYPoint = -screenBounds.y + spriteRenderer.bounds.extents.y;
        var maxYPoint = screenBounds.y - spriteRenderer.bounds.extents.y;

        var nextXPos = Mathf.Clamp(nextPosition.x, minXPoint, maxXPoint);
        var nextYPos = Mathf.Clamp(nextPosition.y, minYPoint, maxYPoint);

        transform.position = new Vector3(nextXPos, nextYPos, 0);

        bool invertX = nextXPos == minXPoint || nextXPos == maxXPoint;
        bool invertY = nextYPos == minYPoint || nextYPos == maxYPoint;

        if (invertX)
        {
            direction.x *= -1;
            spriteRenderer.color = new Color(Random.Range(0.01f, 1f), Random.Range(0.01f, 1f), Random.Range(0.01f, 1f));
        }

        if (invertY)
        {
            direction.y *= -1;
            spriteRenderer.color = new Color(Random.Range(0.01f, 1f), Random.Range(0.01f, 1f), Random.Range(0.01f, 1f));
        }
    }
}
