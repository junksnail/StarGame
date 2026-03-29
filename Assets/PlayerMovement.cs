using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

using System.Collections;


public class PlayerController : MonoBehaviour
{
    [SerializeField] InputActionAsset InputActions;
    public InputAction moveAction;
    public InputAction jumpAction;

    [SerializeField] Transform cam;
    Vector3 camPos;
    private Vector3 camForward;
    private Vector3 camRight;

    Rigidbody rb;

    public float walkSpeed;
    public float smoothSpeed;
    public float jumpForce;

    public bool isGrounded;
    public bool isMoving;
    public bool isSprinting;

    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Animator animator;

    Quaternion targetRotation;

    private void OnEnable()
    {
        InputActions.FindActionMap("Keyboard").Enable();
    }

    private void OnDisable()
    {
        animator.SetBool("isWalking", false);
        InputActions.FindActionMap("Keyboard").Disable();
    }

    void Awake()
    {
        if (InputSystem.actions)
        {
            moveAction = InputSystem.actions.FindAction("Movement");
            jumpAction = InputSystem.actions.FindAction("Jump");

            rb = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        JumpInput();
    }

    void FixedUpdate()
    {
        CamUpdate();
        MoveInput();
    }

    void CamUpdate()
    {
        camPos = cam.position;
    }

    void MoveInput()                                                                 //sets movement to stay relative to camera, not the player, when having a fixed camera...
    {                                                                                //...position, and dynamic camera rotation

        Vector3 camPosition = new Vector3(camPos.x, transform.position.y, camPos.z); //get the vectors of the camera
        Vector3 direction = (transform.position - camPosition).normalized;           //normalize the player position and cam position

        Vector2 input = moveAction.ReadValue<Vector2>();                             //get the input 

        Vector3 forwardMovement = direction * input.y;                               //set the camera relative forward vector
        Vector3 horizontalMovement = cam.right * input.x;                            //set the camera relative right vector
        Vector3 movement = Vector3.ClampMagnitude(forwardMovement + horizontalMovement, 1);
        //set the magnitude of forward + right vectors
        Vector3 nextPos = rb.position + movement * walkSpeed * Time.deltaTime;       //set the next position of the player over time
        rb.MovePosition(nextPos);
        if (input.x > 0)
        {
            sprite.transform.localScale = new Vector3(3.66f, 3.66f, 3.66f);
        }
        if (input.x < 0)
        {
            sprite.transform.localScale = new Vector3(-3.66f, 3.66f, 3.66f);
        }
        if ( input !=  new Vector2(0,0))
        {
            animator.SetBool("isWalking", true);
        }
        if (input == new Vector2(0, 0))
        {
            animator.SetBool("isWalking", false);
        }

    }

    void JumpInput()
    {
        if (isGrounded && jumpAction.IsPressed())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
   
    public void SprintAbility()
    {
        if (!isSprinting) { StartCoroutine(SprintAbilityUse()); }
    }

    public IEnumerator SprintAbilityUse()
    {
        isSprinting = true;
        walkSpeed = walkSpeed * 1.7f;
        yield return new WaitForSeconds(5f);
        walkSpeed = walkSpeed / 1.7f;
        isSprinting = false;
    }
}

