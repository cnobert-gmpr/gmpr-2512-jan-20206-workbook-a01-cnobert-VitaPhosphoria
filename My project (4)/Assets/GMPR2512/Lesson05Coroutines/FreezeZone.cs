using System.Collections;
using UnityEngine;

namespace GMPR2512.Lesson05Coroutines
{
    public class FreezeZone : MonoBehaviour
    {
        [SerializeField] private float _FreezeSeconds = 1.5f;
        private void OnTriggerEnter2D(Collider2D collider)
        {
            Rigidbody2D rb = collider.attachedRigidbody;
            if (rb == null)
            {
                return;
            }
            StartCoroutine(FreezeRoutine(rb));
        }
        private IEnumerator FreezeRoutine(Rigidbody2D rb)
        {
            Vector2 savedVelocity = rb.linearVelocity;
            float savedGravity = rb.gravityScale;

            rb.linearVelocity = Vector2.zero;
            rb.gravityScale = 0f;

            yield return new WaitForSeconds(_FreezeSeconds);

            rb.linearVelocity = savedVelocity;
            rb.gravityScale = savedGravity;
        }
    }
}
