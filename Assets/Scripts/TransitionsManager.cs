using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionsManager : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadLevel()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void LoadMainMenu()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex - 1));
    }
    public void ReloadLevel()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
