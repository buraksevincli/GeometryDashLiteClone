using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAgainButton : MonoBehaviour
{
    private Button _playAgainButton;

    private void Awake()
    {
        _playAgainButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _playAgainButton.onClick?.AddListener(PlayAgainButtonAction);
    }

    private void OnDisable()
    {
        _playAgainButton.onClick?.RemoveListener(PlayAgainButtonAction);
    }

    private void PlayAgainButtonAction()
    {
        SceneManager.LoadScene(1);
    }
}
