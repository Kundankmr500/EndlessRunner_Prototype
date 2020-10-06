using UnityEngine;
using System.Collections;
using Player;


namespace Environment
{
    public class ObstacleView : MonoBehaviour
    {
        public void Init()
        {
            Enable();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<IDestructable>() != null)
            {
                IDestructable targetHealth = other.GetComponent<IDestructable>();
                targetHealth.TakeDamage(1);

                StartCoroutine(PlayerPause(other.GetComponent<PlayerView>()));
            }
        }

        IEnumerator PlayerPause(PlayerView playerView)
        {
            playerView.enabled = false;
            yield return new WaitForSeconds(2f);
            playerView.enabled = true;
            gameObject.SetActive(false);
        }

        internal void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
