using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public int sceneToLoad;

    public void OnTriggerEnter2D(Collider2D other)
    {
        PlayerAttributes player = other.gameObject.GetComponent<PlayerAttributes>();
        if (player)
        {
            load(sceneToLoad);
        }
    }
    public void load(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void load(int sceneIndex)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneIndex);
    }
}
