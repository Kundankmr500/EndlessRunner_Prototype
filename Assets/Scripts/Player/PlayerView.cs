using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        public RoadSide roadSide;
        public Animator PlayerAnimator;
        [SerializeField]
        private CharacterController characterController;
        [SerializeField]
        private float forwardSpeed;
        private PlayerController playerController;

        private int distanceBetweenLane;
        private float PlayerHeightValue = 2;
        [SerializeField]
        private float NewLanePos = 0f;
        private float YValueForVerticle = 0f;

        private bool SwipeLeft { get; set; }
        private bool SwipeRight { get; set; }
        private bool SwipeUp { get; set; }
        private bool SwipeDown { get; set; }

        public void Initialize(PlayerController playerController)
        {
            this.playerController = playerController;
            forwardSpeed = playerController.GetModel().ForwardSpeed;
            distanceBetweenLane = playerController.GetModel().DistanceBetweenLane;
            characterController = GetComponentInChildren<CharacterController>();
            roadSide = RoadSide.Mid;
        }

        void FixedUpdate()
        {
            PlayerInput();
            CheckRoadLane();
            PlayerJump();
            PlayerSlide();
        }

        internal void CheckPlayerTransform()
        {
            
        }


        private void PlayerInput()
        {
            SwipeLeft =  Input.GetKeyDown(playerController.GetModel().PlayerLeftKey) || 
                         Input.GetKeyDown(playerController.GetModel().PlayerLeftKeyAlter);
            SwipeRight = Input.GetKeyDown(playerController.GetModel().PlayerRightKey) || 
                         Input.GetKeyDown(playerController.GetModel().PlayerRightKeyAlter);
            SwipeUp =    Input.GetKeyDown(playerController.GetModel().PlayerUpKey) || 
                         Input.GetKeyDown(playerController.GetModel().PlayerUpKeyAlter);
            SwipeDown =  Input.GetKeyDown(playerController.GetModel().PlayerDownKey) || 
                         Input.GetKeyDown(playerController.GetModel().PlayerDownKeyAlter);

        }


        private void CheckRoadLane()
        {
            if (SwipeLeft)
            {
                if (roadSide == RoadSide.Mid)
                {
                    NewLanePos = -distanceBetweenLane;
                    roadSide = RoadSide.Left;
                    PlayerAnimator.Play(AnimationName.Left);
                }
                else if (roadSide == RoadSide.Right)
                {
                    NewLanePos = 0;
                    roadSide = RoadSide.Mid;
                    PlayerAnimator.Play(AnimationName.Left);
                }
            }
            else if (SwipeRight)
            {
                if (roadSide == RoadSide.Mid)
                {
                    NewLanePos = distanceBetweenLane;
                    roadSide = RoadSide.Right;
                    PlayerAnimator.Play(AnimationName.Right);
                }
                else if (roadSide == RoadSide.Left)
                {
                    NewLanePos = 0;
                    roadSide = RoadSide.Mid;
                    PlayerAnimator.Play(AnimationName.Right);
                }
            }

            CalculatingPlayerNextPos();
        }


        private void CalculatingPlayerNextPos()
        {

            Vector3 moveVector = new Vector3((PlayerHeightValue - transform.position.x), 
                                 YValueForVerticle * Time.deltaTime, forwardSpeed * Time.deltaTime);

            PlayerHeightValue = Mathf.Lerp(PlayerHeightValue, NewLanePos, 
                                Time.deltaTime * playerController.GetModel().LaneChangeSpeed);

            characterController.Move(moveVector);


        }


        private void PlayerJump()
        {
            if(characterController.isGrounded && SwipeUp)
            {
                YValueForVerticle = playerController.GetModel().JumpForce;
                PlayerAnimator.Play(AnimationName.Jump);

            }
            else
            {
                YValueForVerticle -= playerController.GetModel().JumpForce * 
                                     playerController.GetModel().GravityValue * Time.deltaTime;
            }
        }


        private void PlayerSlide()
        {
            if (characterController.isGrounded && SwipeDown)
            {
                PlayerAnimator.Play(AnimationName.Slide);

            }
        }
    }
}
