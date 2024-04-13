using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void scenechange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void leaveGame()
    {
        Application.Quit();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
