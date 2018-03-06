using UnityEngine;
using UnityEngine.UI;

public class Player_Control : MonoBehaviour { // Скрипт для управления Игроком и проверки косания бонусов
    public float Speed;           // Скорость игрока
    public float High_Jump;       // Высота прыжка
    public int Food_Count;        // Кол-во еды на уровне
    public Text Score_Text;       // Текстовый счёт
    public Text Win_Text;         // "Вы победили!"
    public string Movement_Style; // 
    private Rigidbody RB;         // Физика игрока
    private int Score_Int;        // Числовой счёт
    private bool Jumped = false;  // В прыжке?


    void Start() // При старте:
    {
        RB = GetComponent<Rigidbody>(); // Узнать физику
        Win_Text.text = "";             // Оставить поле Победы пустым
        Score_Int = 0;                  // Обнулить Числовой Счёт
        Score_Text_Update();            // Обновить Текстовый Счёт
    }

    void FixedUpdate() // Каждые 0.2 секунды:
    {
        Movement();        // Движение
        Ray_Down_Jumped(); // Луч, проверяющий касание земли
    }

    private void Movement () // Движение
    {
        if (Movement_Style == "Acceleration") {
            Vector3 Acceleration = Input.acceleration;                            // 3D вектор со значениями акселерометра (Нужны X-Z)
            Vector3 Movement = new Vector3(Acceleration.x, 0.0f, Acceleration.y); // 3D вектор - сложение векторов (В телефоне это оси X-Y)
            RB.AddForce(Movement * Speed);                                        // Изменить позицию на Вектор * Скорость
        }
        else if (Movement_Style == "Keyboard") {
            float Move_Horizontal = Input.GetAxis("Horizontal");                  // Нажато ли ВЛЕВО-ВПРАВО (-1/1)
            float Move_Vertical = Input.GetAxis("Vertical");                      // Нажато ли ВНИЗ-ВВЕРХ   (-1/1)
            Vector3 Movement = new Vector3(Move_Horizontal, 0.0f, Move_Vertical); // 3D вектор - сложение векторов
            RB.AddForce(Movement * Speed);                                        // Изменить позицию на Вектор * Скорость
        }
        else if (Movement_Style == "Joystick")
        {
           
        }

    }

    private void Ray_Down_Jumped() // Луч, проверяющий касание земли
    {
        Ray Ray_Down = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit RcH;
        if (Physics.Raycast(Ray_Down, out RcH, 0.5f))
        {
            Jumped = false;
        }
        else
        {
            Jumped = true;
        }
    }

    public void Jump_Function()
    {
        if (!Jumped && !Menu_In_Game.Paused)
        {
            RB.AddForce(Vector3.up * High_Jump);
        }
    }

    private void OnTriggerEnter(Collider Other) // При косании объекта со значение Trigger:
    {
        if (Other.tag == "Food")  // Если его тег "Food"
        {
            Destroy(Other.gameObject);   // Удалить этот объект
            Score_Int++;                 // Увеличить Числовой Счёт на 1
            Score_Text_Update();         // Обновить Тестовый Счёт
            if (Score_Int >= Food_Count) // Если вся еда собрана
            {
                Win_Text.text = "You WON!";  // Вы победили!
            }
        }
    }

    void Score_Text_Update () // Обновить текстовый счёт
    {
        Score_Text.text = "Score: " + Score_Int; // Текст + Счёт
    }
}