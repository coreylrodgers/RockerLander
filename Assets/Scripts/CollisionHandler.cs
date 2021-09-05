using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{


private int currentSceneIndex;
    
    void Start()
    {
         currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

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
                NextLevel();
                break;
            default:
                Debug.Log("Hit an obstacle");
                Respawn();
                break;
        }
    }

    void Respawn()
    {
        SceneManager.LoadScene (currentSceneIndex);
    }

    void NextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
