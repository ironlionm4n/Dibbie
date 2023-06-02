using UnityEngine;

namespace Ball
{
    public class Ball : MonoBehaviour, IBall
    {
        public void Detection()
        {
            Debug.Log("Detected");
        }
    }
}