using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 500f;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float acceleration = 1f;

    private Rigidbody2D rb2D;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
       
    }


    public void MoveTowardsTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        rb2D.velocity = direction * speed;       
    }


    private void FixedUpdate()
    {
        Vector2 moveDir = new Vector2(0.1f, 0.3f);

        // Calculate acceleration effect on current speed
        currentSpeed += acceleration * Time.fixedDeltaTime;

        // Clamp speed to prevent exceeding a maximum (optional)
        currentSpeed = Mathf.Clamp(currentSpeed, 0f, speed); // Max speed is still 'speed'

        float currXSpeed = currentSpeed * Time.fixedDeltaTime * moveDir.x;
        float currYSpeed = currentSpeed * Time.fixedDeltaTime * moveDir.y;

        rb2D.velocity = new Vector2(currXSpeed, currYSpeed);
    }

    [ProButton]
    private void Move()
    {
        currentSpeed = speed;
    }

    [ProButton]
    private void Stop()
    {
        currentSpeed = 0f;
    }

}
