using Singalton;
using UnityEngine;
using TMPro;
using System.Collections;
using Player;

namespace Game
{
    public class GameService : MonoBehaviour
    {
        public int GameStartTimer = 3;
        public TextMeshProUGUI HealthUI;
        public TextMeshProUGUI StartTimerUI;
        public GameObject GamePauseButton;
        public GameObject GameOverUI;
        public bool GameResume;
        [SerializeField]
        private int PlayerHealth = 3;
        private PlayerController playerController;


        private void Start()
        {
            ShowHealthOnScreen(PlayerHealth);
            SubscribeEvents();
            StartCoroutine(StartCountdown(GameStartTimer));
        }


        public void SetPlayerController(PlayerController playerController)
        {
            this.playerController = playerController;
        }


        // start with countdown timer
        private IEnumerator StartCountdown(int countdownValue)
        {
            StartTimerUI.transform.parent.gameObject.SetActive(true);
            while (countdownValue > -1)
            {
                yield return new WaitForSeconds(.9f);
                countdownValue--;
                StartTimerUI.text = countdownValue.ToString();
            }

            GameStart();
        }

        private void GameStart()
        {
            StartTimerUI.transform.parent.gameObject.SetActive(false);
            playerController.PlayerView.enabled = true;
            GamePauseButton.SetActive(true);
            GameResume = true;
        }

        private void SubscribeEvents()
        {
            EventService.Instance.OnPlayerHit += UpdatePlayerHealth;
        }

        private void UpdatePlayerHealth(int amount)
        {
            PlayerHealth = PlayerHealth - amount;
            ShowHealthOnScreen(PlayerHealth);

            if(PlayerHealth == 0) //game over
            {
                GameOverUI.SetActive(true);
                GameResume = false;
                Time.timeScale = 0;
            }
        }

        private void ShowHealthOnScreen(int health)
        {
            HealthUI.text = Constants.Health + health;
        }

        private void UnsubscribeEvents()
        {
            EventService.Instance.OnPlayerHit -= UpdatePlayerHealth;
        }

        public void GamePause(TextMeshProUGUI text)
        {
            if (GameResume)
            {
                GameResume = false;
                text.text = Constants.Resume;
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                GameResume = true;
                text.text = Constants.Pause;
            }
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }
    }
}
