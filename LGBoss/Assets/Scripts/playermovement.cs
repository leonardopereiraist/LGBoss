using UnityEngine;
using UnityEngine.InputSystem;

public class playermovement : MonoBehaviour
{
    [SerializeField]private float moveSpeed, sprintSpeed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    private bool isSprinting;
    private PlayerStats player;

    public float sprintSpend;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerStats>();
        
    }

    // Update is called once per frame
    void Update()
    {

        float speed = isSprinting ? sprintSpeed : moveSpeed;
        rb.linearVelocity = moveInput * speed;

        if (isSprinting)
            if (!player.SpendStamina(sprintSpend/1000))
            {
                isSprinting = false;        
            }
        
    }


    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);

        if (context.canceled)
        {
           animator.SetBool("isWalking", false);
           animator.SetFloat("LastInputX", moveInput.x);
           animator.SetFloat("LastInputY", moveInput.y);
        }
        
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);

    }   

        public void Sprint(InputAction.CallbackContext context)
    {
        isSprinting = context.performed;            
    }   
}
