using System;
using UnityEngine;

namespace Player
{
    public class CollisionZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IBall>(out var ball))
            {
                ball.Detection();
            }
        }
    }
}