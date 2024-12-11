using UnityEngine;

public class Parallax : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layerTransform; // Ссылка на слой
        public float parallaxFactor;     // Коэффициент параллакса (чем меньше, тем медленнее слой движется)
        public float layerLenght;
    }


    public ScorePlatformScript ScorePlatformScript;
    public GameObject ScorePlatform;
    
    public ParallaxLayer[] layers;      // Массив слоев
    private float backgroundSpeed = 5f;  // Скорость движения фона
    private Vector3 startPosition;      // Начальное положение персонажа или камеры

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        ScorePlatform = GameObject.FindGameObjectWithTag("ScorePlatform");
        ScorePlatformScript = ScorePlatform.GetComponent<ScorePlatformScript>();
        backgroundSpeed = ScorePlatformScript.fspeed;

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
                layer.layerLenght = layer.layerTransform.GetComponent<SpriteRenderer>().bounds.size.x;
                if (layer.layerTransform.position.x < -layer.layerLenght)
                {
                    layer.layerTransform.position += new Vector3(layer.layerLenght*2 - 0.5f, 0, 0);
                    //GameObject go = layer;
                    //newLayerPosition = new Vector3(dessaperRadius, layer.layerTransform.position.y, layer.layerTransform.position.z);
                    //GameObject newLayer = Instantiate(layer, newLayerPosition, Quaternion.identity);
                }
            }
        }
    }
}