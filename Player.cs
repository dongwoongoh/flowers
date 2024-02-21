using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private CircleCollider2D circleCollider;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();

    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);
        Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;

        Vector2 lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector2 upperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        float playerRadius = circleCollider.radius * Mathf.Max(transform.localScale.x, transform.localScale.y);

        newPosition.x = Mathf.Clamp(newPosition.x, lowerLeft.x + playerRadius, upperRight.x - playerRadius);
        newPosition.y = Mathf.Clamp(newPosition.y, lowerLeft.y + playerRadius, upperRight.y - playerRadius);

        transform.position = newPosition;
    }
}