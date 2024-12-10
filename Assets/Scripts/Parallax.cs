using UnityEngine;

public class Parallax : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layerTransform; // Ссылка на слой
        public float parallaxFactor;     // Коэффициент параллакса (чем меньше, тем медленнее слой движется)
    }


    public PlatformMove PlatformMove;
    public ParallaxLayer[] layers;      // Массив слоев
    private float backgroundSpeed = 5f;  // Скорость движения фона
    private Vector3 startPosition;      // Начальное положение персонажа или камеры

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        backgroundSpeed = PlatformMove.speed;
        Debug.Log(backgroundSpeed);
        // Рассчитываем движение по оси X
        float movement = backgroundSpeed * Time.deltaTime;

        foreach (var layer in layers)
        {
            if (layer.layerTransform != null)
            {
                Vector3 newLayerPosition = layer.layerTransform.position;
                // Двигаем слой в зависимости от его коэффициента параллакса
                newLayerPosition.x -= movement * layer.parallaxFactor;
                layer.layerTransform.position = newLayerPosition;
            }
        }
    }
}