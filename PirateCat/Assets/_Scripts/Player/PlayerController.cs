using UnityEngine;
using System.Threading.Tasks;

namespace Blobbers.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : PlayerControllerInput
    {
        public Vector3 CurrentVelocity { get; private set; }
        public bool IsGrounded => controller.isGrounded;
        public bool IsRunning { get; private set; }
        public bool IsJumping { get; private set; }

        [Header("Horizontal Movement")]
        [SerializeField] float walkSpeed = 3;
        [SerializeField] float runSpeed = 5;
        [SerializeField] float moveAcceleration = 20;

        [Header("Veritcal Speed")]
        [SerializeField] float fallSpeed = -15;
        [SerializeField] float fallAcceleraction = 30;
        [SerializeField] float jumpSpeed = 8;
        
        CharacterController controller;
        Camera cam;

        Vector3 moveVector = Vector3.zero;
        float currentHorSpeed = 0;
        float currentVertSpeed = 0;

        void Awake()
        {
            controller = GetComponent<CharacterController>();
            cam = Camera.main;
        }

        void Update()
        {
            CalculateHorizontalSpeed();
            CalculateVerticalSpeed();

            CurrentVelocity = new Vector3(moveVector.x, currentVertSpeed, moveVector.z);

            controller.Move(CurrentVelocity * Time.deltaTime);
        }

        void CalculateHorizontalSpeed()
        {
            IsRunning = InputRun;

            float _targetSpeed = 0;

            if (InputMove != Vector3.zero)
                _targetSpeed = IsRunning ? runSpeed : walkSpeed;

            currentHorSpeed = Mathf.MoveTowards(currentHorSpeed, _targetSpeed, moveAcceleration * Time.deltaTime);
            moveVector = cam.transform.TranformDirectionHorizontal(InputMove) * currentHorSpeed * InputMove.magnitude;
        }

        void CalculateVerticalSpeed()
        {
            if (InputJump)
                Jump();

            if (IsJumping)
            {
                currentVertSpeed = jumpSpeed;
                return;
            }

            if (IsGrounded)
            {
                currentVertSpeed = -1;
                return;
            }

            currentVertSpeed = Mathf.MoveTowards(currentVertSpeed, fallSpeed, fallAcceleraction * Time.deltaTime);
        }

        async void Jump()
        {
            if (!IsGrounded)
                return;

            IsJumping = true;

            await Task.Delay(100);

            IsJumping = false;
        }
    }
}