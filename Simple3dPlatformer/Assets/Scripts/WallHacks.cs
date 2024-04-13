using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHacks : MonoBehaviour
{
    [SerializeField] Transform orientation;
    [SerializeField] Rigidbody rb;
    [SerializeField] LayerMask WallLayer;

    [SerializeField] float climbSpeed;
    [SerializeField] float maxClimbTimer;
    private float climbTimer;

    private bool isClimbing;
    [SerializeField] Player pp;

    [SerializeField] float detectionLength;
    [SerializeField] float sphereRadius;

    [SerializeField] float climbJumpForce;
    [SerializeField] float climbJumpBackForce;
    [SerializeField] int climbJumps;
    private int climbJumpsLeft;

    private Transform lastWall;
    private Vector3 lastWallNormal;
    public float minWallNormalAngleChange;

    private bool wallFront;
    private RaycastHit FrontWallHit;

    private void Update()
    {
        wallCheck();
        StateMachine();

        if (isClimbing)
        {
            climbing();
        }
    }

    void StateMachine()
    {
        if (wallFront && Input.GetKey(KeyCode.W))
        {
            if (!isClimbing && climbTimer > 0)
            {
                startClimbing();
            }
            if (climbTimer > 0)
            {
                climbTimer -= Time.deltaTime;
            }
            if (climbTimer < 0)
            {
                stopClimbing();
            }
        }
        else
        {
            if (isClimbing)
            {
                stopClimbing();
            }
        }

        if(wallFront && Input.GetKey(KeyCode.Space) && climbJumpsLeft>0)
        {
            climbJump();
        }
    }


    void wallCheck()
    {
        wallFront = Physics.SphereCast(transform.position, sphereRadius, orientation.forward, out FrontWallHit, detectionLength, WallLayer);
        bool newWall = FrontWallHit.transform != lastWall || Mathf.Abs(Vector3.Angle(lastWallNormal, FrontWallHit.normal)) > minWallNormalAngleChange;

        if ((wallFront && newWall) || pp.isGrounded)
        {
            climbTimer = maxClimbTimer;
            climbJumpsLeft = climbJumps;
        }
    }

    void startClimbing()
    {
        isClimbing = true;
        lastWall = FrontWallHit.transform;
        lastWallNormal = FrontWallHit.normal;
    }

    void climbing()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);
    }

    void stopClimbing()
    {
        isClimbing = false;
    }

    void climbJump()
    {
        Vector3 forceToApply = transform.up * climbJumpForce + FrontWallHit.normal * climbJumpBackForce;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(forceToApply, ForceMode.Impulse);

        climbJumpsLeft--;
    }
}
