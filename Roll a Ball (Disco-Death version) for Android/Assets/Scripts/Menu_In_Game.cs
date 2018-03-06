using UnityEngine;

public class Menu_In_Game : MonoBehaviour { // Выход в подменю и пауза
    public static bool Paused = false;             // Остановлено ли? == Нет
    public GameObject Menu_In_Game_Panel;   // Панель меню

    public void OnClick () // При нажатии на кнопку
    {
        if (!Paused) // Если нет
        {
            Time.timeScale = 0;                 // Остановить игру
            Paused = true;                      // Переменная == остановлено
            Menu_In_Game_Panel.SetActive(true); // Открыть панель меню
        }
        else
        {
            Time.timeScale = 1;                  // Продолжить игру
            Paused = false;                      // Переменная == не остановлено
            Menu_In_Game_Panel.SetActive(false); // Закрыть панель меню
        }
    }
}