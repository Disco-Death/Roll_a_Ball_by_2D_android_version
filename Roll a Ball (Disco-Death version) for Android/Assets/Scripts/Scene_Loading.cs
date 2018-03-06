using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene_Loading : MonoBehaviour { // Скрипт загрузки сцены/игры
    [Header("Загружаемая сцена")]
    public int Scene_ID;      // ID загружаемой сцены
    [Header("Индикаторы загрузки")]
    public Text Procent;      // Проценты загрузки
    public Image Loading_Bar; // Загрузочный круг    

    private void Start() // При старте:
    {
        StartCoroutine(Asyn_Load());  // Начать загрузку сцены
    }

    IEnumerator Asyn_Load() // Асинхронная загрузка
    {
        AsyncOperation Operator = SceneManager.LoadSceneAsync(Scene_ID); // Загрузить сцену
        while (!Operator.isDone) // Пока сцена загружается
        {
            float Progress = Operator.progress / 0.9f;              // Максимальная загрузка 0.9, исправим это
            Loading_Bar.fillAmount = Progress;                      // Заполненность круга == Прогресс загрузки
            Procent.text = string.Format("{0:0}%", Progress * 100); // Текстовый индикатор (0-100)%, формат для округления
            yield return null;
        }
    }
}