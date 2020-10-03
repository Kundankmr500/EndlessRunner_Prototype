using UnityEngine;


namespace Player
{
    public class PlayerView : MonoBehaviour
    {

        public Animator animator;
        private float InputX;
        private float InputY;
        [SerializeField]
        private CharacterController characterController;
        [SerializeField]
        private float forwardSpeed;
        private PlayerController playerController;

        private int desiredLane = 1;
        private int minDesiredLane;
        private int maxDesiredLane;
        private float laneDistance;


        public void Initialize(PlayerController playerController)
        {
            this.playerController = playerController;
            forwardSpeed = playerController.GetModel().ForwardSpeed;
            laneDistance = playerController.GetModel().LaneDistance;
            minDesiredLane = playerController.GetModel().MinDesiredLane;
            maxDesiredLane = playerController.GetModel().MaxDesiredLane;
        }

        void FixedUpdate()
        {
            PlayerMovement();
            PlayerInput();
        }

        internal void CheckPlayerTransform()
        {
            
        }

        private void PlayerMovement()
        {
            characterController.Move(transform.forward * forwardSpeed * Time.fixedDeltaTime);
        }


        private void PlayerInput()
        {
            InputX = Input.GetAxis("Horizontal");
            InputY = Input.GetAxis("Vertical");
            animator.SetFloat("InputX", InputX);
            animator.SetFloat("InputY", InputY);

            CheckLane();
        }


        private void CheckLane()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                desiredLane++;
                if (desiredLane == maxDesiredLane + 1)
                    desiredLane = maxDesiredLane;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                desiredLane--;
                if (desiredLane == minDesiredLane - 1)
                    desiredLane = minDesiredLane;
            }

            CalculatingPlayerNextPos();
        }


        private void CalculatingPlayerNextPos()
        {
            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

            if (desiredLane == 0)
            {
                targetPosition += Vector3.left * laneDistance;
            }
            else if (desiredLane == 2)
            {
                targetPosition += Vector3.right * laneDistance;
            }

            transform.position = Vector3.Lerp(transform.position, targetPosition,
                                 playerController.GetModel().LaneChangeTime * Time.deltaTime);
        }
    }
}
