using UnityEngine;

namespace Environment
{
    public class CoinView : MonoBehaviour
    {
        public float CoinRotationSpeed;

        void Update()
        {
            transform.Rotate(CoinRotationSpeed * Time.deltaTime, 0, 0);
        }

        private void OnEnable()
        {
            gameObject.SetActive(true);
        }
    }
}
