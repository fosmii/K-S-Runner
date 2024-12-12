using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    [System.Serializable]
    public class SpriteScalePair
    {
        public Sprite sprite;     // ������
        public Vector3 scale;     // �������
    }

    public SpriteScalePair[] spriteScalePairs; // ������ �������� � �� ���������
    private SpriteRenderer spriteRenderer;     // ������ �� SpriteRenderer �������

    void Start()
    {
        // �������� ��������� SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        int randomIndex = Random.Range(0, spriteScalePairs.Length); // ��������� ���������� �������
        SpriteScalePair selectedPair = spriteScalePairs[randomIndex]; // ����� ������� � ��������

        // ��������� ������
        spriteRenderer.sprite = selectedPair.sprite;

        // ��������� �������
        transform.localScale = selectedPair.scale;
    }
}