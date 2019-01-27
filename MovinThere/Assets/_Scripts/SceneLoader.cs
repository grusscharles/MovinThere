using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour {
    [SerializeField]
    [Tooltip("Name of the scene to load")]
    string sceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
