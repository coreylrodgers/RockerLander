using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    //params
    //cache
    AudioSource audioSource;

    [SerializeField]
    AudioClip success;

    [SerializeField]
    AudioClip crash;

    //state
    private int currentSceneIndex;

    //state
    bool isTransitioning = false;

    [SerializeField]
    private float levelLoadDelay = 1;

    void Start()
    {
        //init audio
        audioSource = GetComponent<AudioSource>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning)
        {
            return;
        }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Hit friendly");
                break;
            case "Fuel":
                Debug.Log("Hit fuel");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                Debug.Log("Hit an obstacle");
                Crash();
                break;
        }
        isTransitioning = false;
    }

    void Respawn()
    {
        SceneManager.LoadScene (currentSceneIndex);
    }

    void NextLevel()
    {
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        else
        {
            SceneManager.LoadScene (nextSceneIndex);
        }
    }

    void Crash()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot (crash);

        //disable movement
        GetComponent<Movement>().enabled = false;

        //TODO      //Activate crash sound + particles
        //respawn
        Invoke("Respawn", levelLoadDelay);
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot (success);

        //disable movement
        GetComponent<Movement>().enabled = false;

        //TODO      //Activate crash sound + particles
        //respawn
        Invoke("NextLevel", levelLoadDelay);
    }
}
