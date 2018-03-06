using UnityEngine;

public class Camera : MonoBehaviour { // Скрипт следования камеры за игроком.

    public GameObject Player; // Объект    - Игрок
    private Vector3 Offset;   // 3D вектор - Отступ камеры от игрока

	void Start () {  // При старте:
        Offset = transform.position - Player.transform.position; // Узнать отступ
	}

    private void LateUpdate() // В конце каждого кадра:
    {
        transform.position = Player.transform.position + Offset; // Менять позицию камеры, следя за игроком при отступе
    }
}
