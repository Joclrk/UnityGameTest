using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float DefSpeed = 20f; //set DefualtSpeed
    [SerializeField] float MovSpeed = 10f; //set MoveSpeed
    [SerializeField] float JogSpeed = 20f; //set JogSpeed
    [SerializeField] float SlowSpeed = 20f; //set SlowSpeed
    [SerializeField] float RunSpeed = 30f; //set RunSpeed
    private Rigidbody2D rb; //variable call
    private Vector2 input;
    private Vector2 MousePos;
    //below are currently test variables for a player movement system based on how the player is moving (ie running and jogging make you faster for a set time meanwhile slow makes you slow walk for better aim and controll at the cost of being slower)
    bool IsRun = false;
    bool IsJog = false;
    bool IsSlow = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //variable call
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) //Sprint if Shift pressed
        {
            MovSpeed = JogSpeed;
            IsJog = true;
        }
        else if(Input.GetKey(KeyCode.LeftShift) ||(Input.GetKey(KeyCode.LeftControl)))  //Jog if crtl pressed
        {
            MovSpeed = RunSpeed;
            IsRun = true;
        }
        else if (Input.GetKey(KeyCode.LeftAlt)) //Slow if crtl pressed
        {
            MovSpeed = SlowSpeed;
            IsSlow = true;
        }
        else
        {
            MovSpeed = DefSpeed;
            IsRun = false;
        }
        float DirStart = 180f; //called for angle starting point of player (where the sprite is facing the cursor)
        input.x = Input.GetAxis("Horizontal"); //reads inputs for A and D
        input.y = Input.GetAxis("Vertical"); //reads inputs for W and S
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //calls and finds mouse position
        
        float angle = Mathf.Atan2(MousePos.y - transform.position.y, MousePos.x - transform.position.x) * Mathf.Rad2Deg - DirStart; //angle call to find how a sprite follows the mouses location for player

        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }

    private void FixedUpdate()
    {
        MovSpeed = MovSpeed * Time.fixedDeltaTime;
        rb.linearVelocity = new Vector2(input.x, input.y).normalized * MovSpeed; //move speed calculation and normalization to avoid faster diagonal movement.
    }
}
