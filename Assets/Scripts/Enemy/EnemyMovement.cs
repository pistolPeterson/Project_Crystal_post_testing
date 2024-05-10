using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 500f;
    private bool canMove = true;
    [Header("DEBUG")]
    [SerializeField] private float currentSpeed;
 
     private const float ACCELERATION = 1000f;

    private Rigidbody2D rb2D;
    private Transform CurrentTarget { get; set; }
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //CurrentTarget = null;
    }

    private void FixedUpdate()
    {
        if (!canMove) return;

        if(CurrentTarget != null)
            MoveToPosition();     
    }

    private void MoveToPosition()
    {
        //determine direction
        Vector2 moveDirection = (CurrentTarget.position - transform.position).normalized;

        // Calculate acceleration effect on current speed
        currentSpeed += ACCELERATION * Time.fixedDeltaTime;

        // Clamp speed to prevent exceeding a maximum 
        currentSpeed = Mathf.Clamp(currentSpeed, 0f, speed); 

        float currXSpeed = currentSpeed * Time.fixedDeltaTime * moveDirection.x;
        float currYSpeed = currentSpeed * Time.fixedDeltaTime * moveDirection.y;

        rb2D.velocity = new Vector2(currXSpeed, currYSpeed);
    }

    [ProButton]
    private void Debug_SetPlayerAsTarget()
    {
       GameObject debugPlayer = GameObject.FindWithTag("Player");
        CurrentTarget = debugPlayer.transform;
    }
    public void SetTarget(Transform target) {
        CurrentTarget = target;
    }

    [ProButton]
    public void Move()
    {
        canMove = true;
    }

    [ProButton]
    public void Stop()
    {
        canMove = false;
    }

}
