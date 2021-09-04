using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Hit friendly");
                break;
            case "Fuel":
                Debug.Log("Hit fuel");
                  break;
            case "Player":
                Debug.Log("Hit an obstacle");
                  break;
            default:
                Debug.Log("Hit an obstacle");
                  break;
        }
    }
}
