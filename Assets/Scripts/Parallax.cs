using UnityEngine;

public class Parallax : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layerTransform; // ������ �� ����
        public float parallaxFactor;     // ����������� ���������� (��� ������, ��� ��������� ���� ��������)
    }


    public PlatformMove PlatformMove;
    public ParallaxLayer[] layers;      // ������ �����
    private float backgroundSpeed = 5f;  // �������� �������� ����
    private Vector3 startPosition;      // ��������� ��������� ��������� ��� ������

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        backgroundSpeed = PlatformMove.speed;
        Debug.Log(backgroundSpeed);
        // ������������ �������� �� ��� X
        float movement = backgroundSpeed * Time.deltaTime;

        foreach (var layer in layers)
        {
            if (layer.layerTransform != null)
            {
                Vector3 newLayerPosition = layer.layerTransform.position;
                // ������� ���� � ����������� �� ��� ������������ ����������
                newLayerPosition.x -= movement * layer.parallaxFactor;
                layer.layerTransform.position = newLayerPosition;
            }
        }
    }
}