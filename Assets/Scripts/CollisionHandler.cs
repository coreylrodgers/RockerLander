using UnityEngine;
using UnityEngine.SceneManagement;

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
            case "Finish":
                Debug.Log("Congrats");
                break;
            default:
                Debug.Log("Hit an obstacle");
                Respawn();
                break;
        }
    }

    void Respawn()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene (currentSceneIndex);
    }
}
