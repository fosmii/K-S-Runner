using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // ������ �� Canvas, ������� ����� ������������
    [SerializeField] public Canvas menuCanvas;

    // ������ �� ������, ������� ������ ���������
    [SerializeField] public Button initialButton;

    private void Start()
    {
        menuCanvas.gameObject.SetActive(false);
        initialButton.onClick.AddListener(OnInitialButtonClick);
    }

    private void OnInitialButtonClick()
    {
        // ������ ��������� ������
        Time.timeScale = 0f;
        initialButton.gameObject.SetActive(false);

        // �������� Canvas
        menuCanvas.gameObject.SetActive(true);
    }

    // ������� ��� ������ "������ ������"
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // ������� ��� ������ "��������� � ������� ����"
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // ������� ��� ����� ����
    }

    // ������� ��� ������ "����������"
    public void ContinueGame()
    {
        Time.timeScale = 1f;
        menuCanvas.gameObject.SetActive(false);
        initialButton.gameObject.SetActive(true);
    }
}