using System.Collections;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public static FPSController Instance;

    public bool playerMoving;

    //properties
    public bool CanMove { get; private set; } = true;
    public bool isRunning => canRun && Input.GetKey(KeyCode.LeftShift);
    private float GetCurrentOffset =>  isRunning ? baseStepSpeed * sprintStepMulti : baseStepSpeed;

    [Header("Feature Toggles")]
    public bool canRun = true;
    [SerializeField] bool useHeadbob = true;
    [SerializeField] bool useFootstep = true;

    [Header("Player Options")]
    [SerializeField] float walkSpeed = 3f;
    [SerializeField] float runSpeed = 6f;

    [Header("Camera Options")]
    [Range(0.2f, 6)] public float lookSpeed = 2f;

    [SerializeField, Range(1, 180)] float upperLookLimit = 80f;
    [SerializeField, Range(1, 180)] float lowerLookLimit = 80f;

    [Header("Headbob")]
    [SerializeField] float walkBobSpeed = 14f;
    [SerializeField] float walkBobAmount = 0.05f;

    [SerializeField] float runBobSpeed = 18f;
    [SerializeField] float runBobAmount = 0.11f;

    [Header("Footstep")]
    [SerializeField] float baseStepSpeed = 0.3f;
    [SerializeField] float sprintStepMulti = 0.5f;
    [SerializeField] AudioSource footstepAudio = default;
    [SerializeField] AudioClip[] grass, water, wood, woodStairs, concrete;


    //privates
    float defaultY = 0;
    float timer;

    Camera playerCamera;
    CharacterController characterController;

    Vector3 moveDirection;
    Vector2 currentInput;

    float rotationX = 0f;
    float gravity = 20f;

    float footstepTimer = 0f;


    void Awake()
    {
        Instance = this;
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();

        defaultY = playerCamera.transform.localPosition.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (CanMove)
        {
           // HandleMovementInput();
            HandleMouseLook();

            //ApplyFinalMovements();

        }
    }

    void HandleMovementInput()
    {
        currentInput = new Vector2((isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical"), (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal"));
        float moveDirectionY = moveDirection.y;

        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        moveDirection.y = moveDirectionY;
    }

    void HandleMouseLook()
    {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }

    void HandleFootsteps()
    {
        if (!characterController.isGrounded) return;
        if (currentInput == Vector2.zero) return;

        footstepTimer -= Time.deltaTime;
        if (footstepTimer <= 0)
        {
            RandomizePitch();
            if (Physics.Raycast(playerCamera.transform.position, Vector3.down, out RaycastHit hit, 3))
            {
                switch (hit.collider.tag)
                {
                    case "Footsteps/Grass":
                        footstepAudio.PlayOneShot(grass[Random.Range(0, grass.Length)]);
                        break;
                    case "Footsteps/Water":
                        footstepAudio.PlayOneShot(water[Random.Range(0, water.Length)]);
                        break;
                    case "Footsteps/Wood":
                        footstepAudio.PlayOneShot(wood[Random.Range(0, water.Length)]);
                        break;
                    case "Footsteps/Stairs/Wood":
                        footstepAudio.PlayOneShot(woodStairs[Random.Range(0, woodStairs.Length)]);
                        break;
                    case "Footsteps/Concrete":
                        footstepAudio.PlayOneShot(concrete[Random.Range(0, concrete.Length)]);
                        break;
                }
            }
            footstepTimer = GetCurrentOffset;
        }
    }

    void RandomizePitch()
    {
        footstepAudio.pitch = Random.Range(0.7f, 1.25f);
    }

    void ApplyFinalMovements()
    {
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * Time.deltaTime);
    }
    void HandleHeadBob()
    {

        if (!characterController.isGrounded) return;
        if (Mathf.Abs(moveDirection.x) > 0.1f || Mathf.Abs(moveDirection.z) > 0.1f)
        {
            playerMoving = true;
            timer += Time.deltaTime * (isRunning ? runBobSpeed : walkBobSpeed);
            playerCamera.transform.localPosition = new Vector3(playerCamera.transform.localPosition.x, defaultY + Mathf.Sin(timer) * (isRunning ? runBobAmount : walkBobAmount), playerCamera.transform.localPosition.z);
        }
        else
        {
            playerMoving = false;
            timer += Time.deltaTime * (isRunning ? runBobSpeed : walkBobSpeed);
            playerCamera.transform.localPosition = new Vector3(playerCamera.transform.localPosition.x, defaultY, playerCamera.transform.localPosition.z);
        }
    }
}