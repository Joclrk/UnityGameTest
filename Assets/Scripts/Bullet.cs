using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Bullet : MonoBehaviour
{
    //[Range(1, 50)]
    [SerializeField] float Speed = 5f;

    //[Range(1, 50)]
    [SerializeField] float LifeTime = 5f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this, LifeTime);
    }
    void FixedUpdate()
    {
        rb.linearVelocity = transform.up * Speed * Time.deltaTime; //Moves bullet based on direction fired (Time added for fps issues)
    }
}
