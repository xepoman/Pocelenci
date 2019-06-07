using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    [Header("Загружаемая сценна")]
    public int sceneID;

    public void NewGameLoading()
    {
        SceneManager.LoadSceneAsync(sceneID);
    }
}
