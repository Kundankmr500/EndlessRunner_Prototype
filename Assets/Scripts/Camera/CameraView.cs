using UnityEngine;

namespace Camera
{
    public class CameraView : MonoBehaviour
    {
        [SerializeField]
        private Transform Target;
        private Vector3 offset;
        [SerializeField]
        private float followSpeed = 5;

        public void SetTargetTransform(Transform playerTransform)
        {
            Target = playerTransform;
            offset = transform.position - Target.position;
        }

        void LateUpdate()
        {
            Vector3 newPosition = new Vector3(offset.x + Target.position.x, transform.position.y,
                                     offset.z + Target.position.z);

            transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);
        }
    }
}
