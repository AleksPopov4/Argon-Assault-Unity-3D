using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] ParticleSystem explosionVFX;

    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        explosionVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadScene", delayTime);
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
