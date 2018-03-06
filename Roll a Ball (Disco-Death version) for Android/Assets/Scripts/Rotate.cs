using UnityEngine;

public class Rotate : MonoBehaviour { // Скрипт - анимация вращения

	void Update () {
        transform.Rotate(new Vector3 (45,15,30) * Time.deltaTime); // Вращение
	}
}