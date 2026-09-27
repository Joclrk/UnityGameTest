using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float MovSpeed = 20f; //set movespeed
    private Rigidbody2D rb; //variable call
    private Vector2 input;
    private Vector2 MousePos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //variable call
    }
    void Update()
    {
        float DirStart = 180f; //called for angle starting point of player (where the sprite is facing the cursor)
        input.x = Input.GetAxis("Horizontal"); //reads inputs for A and D
        input.y = Input.GetAxis("Vertical"); //reads inputs for W and S
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //calls and finds mouse position

        float angle = Mathf.Atan2(MousePos.y - transform.position.y, MousePos.x - transform.position.x) * Mathf.Rad2Deg - DirStart; //angle call to find how a sprite follows the mouses location for player

        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(input.x, input.y).normalized * MovSpeed; //move speed calculation and normalization to avoid faster diagonal movement.
    }
}
