using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("References")]
    public PlayerMovementStats moveStats;
    [SerializeField] private Collider2D feetCollider;
    [SerializeField] private Collider2D bodyCollider;

    private Rigidbody2D rb;

    //movement vars
    private Vector2 moveVelocity;
    private bool isFacingRight;

    //collision check vars
    private RaycastHit2D groundHit;
    private RaycastHit2D headHit;
    private RaycastHit2D movingPlatformHit;
    private bool isGrounded;
    private bool isOnHorizontalMovingPlatform;
    private bool isOnVerticalMovingPlatform;
    private bool bumpedHead;

    //jump vars
    public float verticalVelocity { get; private set; }
    private float horizontalMovingPlatformVelocity;
    private float verticalMovingPlatformVelocity;
    private bool isJumping;
    private bool isFastFalling;
    private bool isFalling;
    private float fastFallTime;
    private float fastFallReleaseSpeed;
    private int numberOfJumpsUsed;

    //apex vars
    private float apexPoint;
    private float timePastApexThreshold;
    private bool isPastApexThreshold;

    //jump buffer vars
    private float jumpBufferTimer;
    private bool jumpReleasedDuringBuffer;

    //coyote time vars
    private float coyoteTimer;

    private void Awake()
    {
        isFacingRight = true;

        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        JumpChecks();
        CountTimers();
    }

    private void FixedUpdate()
    {
        CollisionChecks();
        MovingPlatformCheck();
        Jump();

        if (isGrounded)
        {
            Move(moveStats.groundAcceleration, moveStats.groundDeceleration, InputManager.movement);

        }

        else
        {
            Move(moveStats.airAcceleration, moveStats.airDeceleration, InputManager.movement);
        }
    }

    private void OnDrawGizmos()
    {
        if (moveStats.showRunJumpArc)
        {
            DrawJumpArc(moveStats.maxWalkSpeed, Color.white);
        }

        if (moveStats.showRunJumpArc)
        {
            DrawJumpArc(moveStats.maxRunSpeed, Color.red);
        }
    }
    #region Movement



    private void Move (float acceleration, float deceleration, Vector2 moveInput)
    {

        if (isOnHorizontalMovingPlatform)
        {
            
        }

        if (isOnVerticalMovingPlatform)
        {

        }
        if (moveInput != Vector2.zero)
        {
            TurnCheck(moveInput);
            Vector2 targetVelocity = Vector2.zero;

            if (InputManager.runIsHeld)
            {
                if (isOnHorizontalMovingPlatform)
                {
                    targetVelocity = new Vector2(moveInput.x, 0f) * moveStats.maxRunSpeed * horizontalMovingPlatformVelocity;
                }
                else { targetVelocity = new Vector2(moveInput.x, 0f) * moveStats.maxRunSpeed; }
                
            }
            else 
            {
                if (isOnHorizontalMovingPlatform)
                {
                    targetVelocity = new Vector2(moveInput.x, 0f) * moveStats.maxWalkSpeed;
                }
                else
                {
                    targetVelocity = new Vector2(moveInput.x, 0f) * moveStats.maxWalkSpeed;
                }
                
            }

            moveVelocity = Vector2.Lerp(moveVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);
            rb.velocity = new Vector2(moveVelocity.x, rb.velocity.y);
        }

        else if (moveInput == Vector2.zero)
        {
            moveVelocity = Vector2.Lerp(moveVelocity, Vector2.zero, deceleration * Time.fixedDeltaTime);
            rb.velocity = new Vector2(moveVelocity.x, rb.velocity.y);
        }
    }

    private void TurnCheck(Vector2 moveInput)
    {
        if (isFacingRight && moveInput.x < 0)
        {
            Turn(false);
        }

        else if (!isFacingRight && moveInput.x > 0)
        {
            Turn(true);
        }


    }

    private void Turn(bool turnRight)
    {
        if (turnRight)
        {
            isFacingRight = true;
            transform.Rotate(0f, 180f, 0f);

        }

        else
        {
            isFacingRight = false;
            transform.Rotate(0f, -180f, 0f);
        }
    }
    #endregion

    #region Jump


    private void JumpChecks()
    {
        if (InputManager.jumpWasPressed)
        {
            jumpBufferTimer = moveStats.jumpBufferTime;
            jumpReleasedDuringBuffer = false;
        }

        if (InputManager.jumpWasReleased)
        {
            if (jumpBufferTimer > 0f)
            {
                jumpReleasedDuringBuffer = true;
            }    

            if (isJumping && verticalVelocity >0f)
            {
                if (isPastApexThreshold)
                {
                    isPastApexThreshold = false;
                    isFastFalling = true;
                    fastFallTime = moveStats.timeForUpwardsCancel;
                    verticalVelocity = 0f;


                }

                else
                {
                    isFastFalling = true;
                    fastFallReleaseSpeed = verticalVelocity;
                }
            }
        }

        if (jumpBufferTimer > 0f && !isJumping && (isGrounded || coyoteTimer > 0f))
        {
            InitiateJump(1);

            if (jumpReleasedDuringBuffer)
            {
                isFastFalling = true;
                fastFallReleaseSpeed = verticalVelocity;

            }
        }

        else if (jumpBufferTimer > 0f && isJumping && numberOfJumpsUsed < moveStats.numberOfJumpsAllowed)
        {
            isFastFalling = false;
            InitiateJump(1);
        }

        else if (jumpBufferTimer > 0f && isFalling && numberOfJumpsUsed < moveStats.numberOfJumpsAllowed - 1)
        {
            InitiateJump(2);
            isFastFalling = false;
        }

        if ((isJumping || isFalling) && isGrounded && verticalVelocity <= 0f)
        {
            isJumping = false;
            isFalling = false;
            isFastFalling = false;
            fastFallTime = 0f;
            isPastApexThreshold = false;
            numberOfJumpsUsed = 0;

            verticalVelocity = Physics2D.gravity.y;
        }
    }

    private void InitiateJump(int usedJumps)
    {
        if (!isJumping)
        {
            isJumping = true;
        }

        jumpBufferTimer = 0f;
        numberOfJumpsUsed += usedJumps;
        verticalVelocity = moveStats.initialJumpVelocity;
    }

    private void Jump()
    {
        if (isJumping)
        {
            if (bumpedHead)
            {
                isFastFalling = true;
            }

            if (verticalVelocity >=0f)
            {
                apexPoint = Mathf.InverseLerp(moveStats.initialJumpVelocity, 0f, verticalVelocity);

                if (apexPoint > moveStats.apexThreshold)
                {
                    if (!isPastApexThreshold)
                    {
                        isPastApexThreshold = true;
                        timePastApexThreshold = 0f;
                    }

                    if(isPastApexThreshold)
                    {
                        timePastApexThreshold += Time.fixedDeltaTime;

                        if (timePastApexThreshold < moveStats.apexHangTime)
                        {
                            verticalVelocity = 0f;
                        }

                        else
                        {
                            verticalVelocity = -0.01f;
                        }
                    }
                }

                else
                {
                    verticalVelocity += moveStats.gravity * Time.fixedDeltaTime;
                    if (isPastApexThreshold)
                    {
                        isPastApexThreshold = false;
                    }
                }

            }

            else if (!isFastFalling)
            {
                verticalVelocity += moveStats.gravity * moveStats.gravityOnReleaseMultiplier * Time.deltaTime;
            }

            else if (verticalVelocity < 0f)
            {
                if (!isFalling)
                {
                    isFalling = true;
                }
            }

        }

        if (isFastFalling)
        {
            if (fastFallTime >= moveStats.timeForUpwardsCancel)
            {
                verticalVelocity += moveStats.gravity * moveStats.gravityOnReleaseMultiplier * Time.deltaTime;

            }

            else if (fastFallTime < moveStats.timeForUpwardsCancel)
            {
                verticalVelocity = Mathf.Lerp(fastFallReleaseSpeed, 0f, (fastFallTime/moveStats.timeForUpwardsCancel));

            }

            fastFallTime += Time.fixedDeltaTime;
            
           
        }

        if (!isGrounded && !isJumping)
        {
            if (!isFalling)
            {
                isFalling = true;
            }

            verticalVelocity += moveStats.gravity * Time.fixedDeltaTime;
        }

        verticalVelocity = Mathf.Clamp(verticalVelocity, -moveStats.maxFallSpeed, 50f);

        rb.velocity = new Vector2(rb.velocity.x, verticalVelocity);


    }

    #endregion
    #region Collision Checks

    private void IsGrounded()
    {
        Vector2 boxCastOrigin = new Vector2(feetCollider.bounds.center.x, feetCollider.bounds.min.y);
        Vector2 boxCastSize = new Vector2(feetCollider.bounds.size.x, moveStats.groundDetectionRayLength);

        groundHit = Physics2D.BoxCast(boxCastOrigin, boxCastSize, 0f, Vector2.down, moveStats.groundDetectionRayLength, moveStats.groundLayer);

        if (groundHit.collider != null)
        {
            isGrounded = true;

        }
        else { isGrounded = false;}



        
        if (moveStats.debugShowIsGroundedBox)
        {
            Color rayColor;
            if (!isGrounded)
            {
                rayColor = Color.green;
            }

            else { rayColor = Color.red; }

            Debug.DrawRay(new Vector2(boxCastOrigin.x - boxCastSize.x / 2, boxCastOrigin.y), Vector2.down * moveStats.groundDetectionRayLength, rayColor);
            Debug.DrawRay(new Vector2(boxCastOrigin.x + boxCastSize.x / 2, boxCastOrigin.y), Vector2.down * moveStats.groundDetectionRayLength, rayColor);
            Debug.DrawRay(new Vector2(boxCastOrigin.x - boxCastSize.x / 2, boxCastOrigin.y - moveStats.groundDetectionRayLength), Vector2.right * boxCastSize.x, rayColor);
        }
        

    }

    private void MovingPlatformCheck()
    {
        Vector2 boxCastOrigin = new Vector2(feetCollider.bounds.center.x, feetCollider.bounds.min.y);
        Vector2 boxCastSize = new Vector2(feetCollider.bounds.size.x, moveStats.groundDetectionRayLength);

        movingPlatformHit = Physics2D.BoxCast(boxCastOrigin, boxCastSize, 0f, Vector2.down, moveStats.groundDetectionRayLength, moveStats.groundLayer);
        
        
        if (movingPlatformHit.collider != null)
        {
            
            GameObject hitMovingPlatform = movingPlatformHit.collider.gameObject;

            if (hitMovingPlatform.gameObject.tag == "Horizontal Moving Platform")
            {
                isOnHorizontalMovingPlatform = true;
                horizontalMovingPlatformVelocity = hitMovingPlatform.GetComponent<MovingPlatform>().platformMoveSpeed;
            }

            else if (hitMovingPlatform.gameObject.tag == "Vertical Moving Platform")
            {
                isOnVerticalMovingPlatform = true;
                verticalMovingPlatformVelocity = hitMovingPlatform.GetComponent<MovingPlatform>().platformMoveSpeed;
            }

            



        }

        else
        {
            isOnHorizontalMovingPlatform = false;
            isOnVerticalMovingPlatform = false;
        }




    }

    private void BumpedHead()
    {
        Vector2 boxCastOrigin = new Vector2(feetCollider.bounds.center.x, bodyCollider.bounds.max.y);
        Vector2 boxCastSize = new Vector2(feetCollider.bounds.size.x * moveStats.headWidth, moveStats.headDetectionRayLength);

        headHit = Physics2D.BoxCast(boxCastOrigin, boxCastSize, 0f, Vector2.up, moveStats.headDetectionRayLength, moveStats.groundLayer);

        if (headHit.collider != null)
        {
            bumpedHead = true;

        }
        else
        {
            bumpedHead = false;
        }
    }
    private void CollisionChecks()
    {
        IsGrounded();
        BumpedHead();
    }


    #endregion

    #region Timers
    
    private void CountTimers()
    {
        jumpBufferTimer -= Time.deltaTime;

        if (!isGrounded)
        {
            coyoteTimer -= Time.deltaTime;
        }

        else { coyoteTimer = moveStats.jumpCoyoteTime; }
    }
    #endregion

    #region Drawing Jump Arc
    private void DrawJumpArc(float moveSpeed, Color gizmoColor)
    {
        Vector2 startPosition = new Vector2(feetCollider.bounds.center.x, feetCollider.bounds.min.y);
        Vector2 previousPosition = startPosition;
        float speed = 0f;
        if (moveStats.drawRight)
        {
            speed = moveSpeed;
        }
        else { speed = -moveSpeed; }
        Vector2 velocity = new Vector2(speed, moveStats.initialJumpVelocity);

        Gizmos.color = gizmoColor;

        float timeStep = 2 * moveStats.timeTillJumpApex / moveStats.arcResolution;

        for (int i = 0; i < moveStats.visualizationSteps; i++)
        {
            float simulationTime = i * timeStep;
            Vector2 displacement;
            Vector2 drawPoint;

            if (simulationTime < moveStats.timeTillJumpApex)
            {
                displacement = velocity * simulationTime + 0.5f * new Vector2(0, moveStats.gravity) * simulationTime * simulationTime;

            }

            else if (simulationTime < moveStats.timeTillJumpApex + moveStats.apexHangTime)
            {
                float apexTime = simulationTime - moveStats.timeTillJumpApex;
                displacement = velocity * moveStats.timeTillJumpApex + 0.5f * new Vector2(0, moveStats.gravity) * moveStats.timeTillJumpApex * moveStats.timeTillJumpApex;
                displacement += new Vector2(speed, 0) * apexTime;
            }

            else
            {
                float descendTime = simulationTime - (moveStats.timeTillJumpApex - moveStats.apexHangTime);
                displacement = velocity * moveStats.timeTillJumpApex + 0.5f * new Vector2(0, moveStats.gravity) * moveStats.timeTillJumpApex * moveStats.timeTillJumpApex;
                displacement += new Vector2(speed, 0) * moveStats.apexHangTime;
                displacement += new Vector2(speed, 0) * descendTime + 0.5f * new Vector2(0, moveStats.gravity) * descendTime * descendTime;

            }

            drawPoint = startPosition + displacement;
            
            if (moveStats.stopOnCollision)
            {
                RaycastHit2D hit = Physics2D.Raycast(previousPosition, drawPoint - previousPosition, Vector2.Distance(previousPosition, drawPoint), moveStats.groundLayer);
                if (hit.collider == null)
                {
                    Gizmos.DrawLine(previousPosition, hit.point);
                    break;
                }
            }

            Gizmos.DrawLine (previousPosition, drawPoint);
            previousPosition = drawPoint;
        }

        
   

    }


    #endregion




}