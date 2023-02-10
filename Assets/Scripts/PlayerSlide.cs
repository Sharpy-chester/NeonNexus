using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    Rigidbody rb;
    PlayerMovement playerMove;

    [SerializeField] float maxSlideTime;
    float currentSlideTime = 0;
    [SerializeField] float slideForce;
    [SerializeField] float slideScale;
    [SerializeField] float downForce;
    Transform cam;
    float startingScale;
    bool sliding = false;

    void Start()
    {
        startingScale = transform.localScale.y;
        rb = GetComponent<Rigidbody>();
        playerMove = GetComponent<PlayerMovement>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Slide") && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            StartSliding();
        }

        if (Input.GetButtonUp("Slide") && sliding)
        {
            StopSliding();
        }
    }

    void FixedUpdate()
    {
        if (sliding)
        {
            SlidingMovement();
        }
    }

    void StartSliding()
    {
        sliding = true;
        transform.localScale = new Vector3(transform.localScale.x, slideScale, transform.localScale.z);
        rb.AddForce(Vector3.down * downForce, ForceMode.Impulse);
        currentSlideTime = maxSlideTime;
        playerMove.canRun = false;
    }

    void StopSliding()
    {
        sliding = false;
        transform.localScale = new Vector3(transform.localScale.x, startingScale, transform.localScale.z);
        playerMove.canRun = true;
    }

    void SlidingMovement()
    {
        currentSlideTime -= Time.fixedDeltaTime;
        Vector3 dir = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
        rb.AddForce(dir.normalized * slideForce, ForceMode.Force);
        if(currentSlideTime <= 0)
        {
            StopSliding();
        }
    }
}
