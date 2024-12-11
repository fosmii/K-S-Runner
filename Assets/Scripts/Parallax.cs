using UnityEngine;

public class Parallax : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layerTransform; // ������ �� ����
        public float parallaxFactor;     // ����������� ���������� (��� ������, ��� ��������� ���� ��������)
        public float layerLenght;
    }


    public ScorePlatformScript ScorePlatformScript;
    public GameObject ScorePlatform;
    
    public ParallaxLayer[] layers;      // ������ �����
    private float backgroundSpeed = 5f;  // �������� �������� ����
    private Vector3 startPosition;      // ��������� ��������� ��������� ��� ������

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        ScorePlatform = GameObject.FindGameObjectWithTag("ScorePlatform");
        ScorePlatformScript = ScorePlatform.GetComponent<ScorePlatformScript>();
        backgroundSpeed = ScorePlatformScript.fspeed;

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