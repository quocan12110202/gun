using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    private Camera maincamera;
    public GameObject bulletPrefabs;
    public Transform firePoint;
    public float fireRate = 1f;
    private float nextFireTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        maincamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        UpdateAnimationState();
        if(Input.GetMouseButtonDown(0)&&Time.time>=nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = moveInput.normalized * moveSpeed;
        RotatePlayer();
    }
    void UpdateAnimationState()
    {
        if(moveInput.magnitude>0)
        {
            animator.SetBool("isRun", true);
        }    
        else
        {
            animator.SetBool("isRun", false);
        }
    }
    void RotatePlayer()
    {
        Vector2 mousePosition=maincamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
    void Shoot()
    {
        Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
        AudioManager.instance.PlayShootClip();
    }
}
