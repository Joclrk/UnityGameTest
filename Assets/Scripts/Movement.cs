using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float MovSpeed = 20f; //set movespeed
    private Rigidbody2D rb; //variable call
    private Vector2 input;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //variable call
    }
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        input.Normalize(); //fixes diagonal movement to not be faster
        rb.linearVelocity = input * MovSpeed; //movement calculation
    }
}
