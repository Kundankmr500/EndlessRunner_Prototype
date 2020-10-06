using Environment;
using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour, IDestructable
    {
        public RoadLane roadLane;
        public Animator PlayerAnimator;
        [SerializeField]
        private CharacterController characterController;
        [SerializeField]
        private float forwardSpeed;
        private PlayerController playerController;

        private float distanceBetweenLane;
        private float PlayerHeightValue = 0;
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
            roadLane = RoadLane.Mid;
        }

        void FixedUpdate()
        {
            PlayerInput();
        }
  

        void Update()
        {
            CheckRoadLane();
            PlayerJump();
            PlayerSlide();
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
                if (roadLane == RoadLane.Mid)
                {
                    NewLanePos = -distanceBetweenLane;
                    roadLane = RoadLane.Left;
                    PlayerAnimator.Play(AnimationName.Left);
                }
                else if (roadLane == RoadLane.Right)
                {
                    NewLanePos = 0;
                    roadLane = RoadLane.Mid;
                    PlayerAnimator.Play(AnimationName.Left);
                }
            }
            else if (SwipeRight)
            {
                if (roadLane == RoadLane.Mid)
                {
                    NewLanePos = distanceBetweenLane;
                    roadLane = RoadLane.Right;
                    PlayerAnimator.Play(AnimationName.Right);
                }
                else if (roadLane == RoadLane.Left)
                {
                    NewLanePos = 0;
                    roadLane = RoadLane.Mid;
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


        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<CoinView>())
            {
                other.gameObject.SetActive(false);
                playerController.FireOnCoinPickedEvent(10);
            }
        }

        public void TakeDamage(int amount)
        {
            playerController.FireOnPlayerHitEvent(amount);
        }
    }
}
