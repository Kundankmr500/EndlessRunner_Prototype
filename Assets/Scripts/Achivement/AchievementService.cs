using Singalton;
using UnityEngine;
using TMPro;
using Game;
using Player;

namespace Achievement
{
    public class AchievementService : MonoBehaviour
    {
        public GameService GameService;
        public TextMeshProUGUI ScoreUI;
        public TextMeshProUGUI TimeUI;
        public TextMeshProUGUI DistanceUI;

        [SerializeField]
        private int playerScore = 0;
        private float playerTime = 0;
        private int lastPlayerTime = 0;
        private Vector3 previousPosition;
        private float distance;
        private float prevdistance;
        private PlayerController playerController;

        private void Start()
        {
            ShowScoreOnScreen(playerScore);
            SubscribeEvents();
        }


        public void SetPlayerController(PlayerController playerController)
        {
            this.playerController = playerController;
            previousPosition = playerController.PlayerView.transform.position;
        }


        private void Update()
        {
            if(GameService.GameResume)
            {
                CalculateTimeTaken();
                CalculateDistanceCovered();
            }

        }

        private void SubscribeEvents()
        {
            EventService.Instance.OnCoinPicked += ScoreUpdated;
        }

        public void ScoreUpdated(int scoreValue)
        {
            playerScore = playerScore + scoreValue;
            ShowScoreOnScreen(playerScore);
        }


        //Show player Score to th User
        private void ShowScoreOnScreen(int score)
        {
            ScoreUI.text = Constants.Score + score;
        }


        //Distance covered by the player
        private void CalculateDistanceCovered()
        {
            distance += Vector3.Distance(previousPosition, playerController.PlayerView.transform.position);
            previousPosition = playerController.PlayerView.transform.position;

            if (distance >= prevdistance + 1)
            {
                prevdistance = distance;
                DistanceUI.text = Constants.Distance + distance.ToString("F2") + Constants.Meter;
            }
        }


        //Time taken by the player
        private void CalculateTimeTaken()
        {
            playerTime += Time.deltaTime;

            if (playerTime >= lastPlayerTime + 1)
            {
                lastPlayerTime = (int)playerTime;
                TimeUI.text = Constants.Time + (int)playerTime;
            }
            
        }

        private void UnsubscribeEvents()
        {
            EventService.Instance.OnCoinPicked -= ScoreUpdated;
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }
    }
}
