using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public SendEmail control;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Good"))
        {
            control.AddPoint();
        }

        if (other.CompareTag("Bad"))
        {
            control.LoseGame();
        }
    }
}