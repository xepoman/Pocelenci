﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenaLoading : MonoBehaviour
{
    [Header("Загружаемая сценна")]
    public int sceneID;
    [Header("Остальные обьекты")]
    public Image loadingImg;
    public Text progresText;

    private void Start()
    {
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loadingImg.fillAmount = progress;
            progresText.text = string.Format("{0:0}%", progress);
            yield return null; // пропустили кадр
        }
    }
}
