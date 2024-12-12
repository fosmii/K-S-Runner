using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    [System.Serializable]
    public class SpriteScalePair
    {
        public Sprite sprite;     // Спрайт
        public Vector3 scale;     // Масштаб
    }

    public SpriteScalePair[] spriteScalePairs; // Массив спрайтов и их масштабов
    private SpriteRenderer spriteRenderer;     // Ссылка на SpriteRenderer объекта

    void Start()
    {
        // Получаем компонент SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        int randomIndex = Random.Range(0, spriteScalePairs.Length); // Генерация случайного индекса
        SpriteScalePair selectedPair = spriteScalePairs[randomIndex]; // Выбор спрайта и масштаба

        // Назначаем спрайт
        spriteRenderer.sprite = selectedPair.sprite;

        // Назначаем масштаб
        transform.localScale = selectedPair.scale;
    }
}