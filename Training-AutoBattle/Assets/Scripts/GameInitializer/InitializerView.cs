using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class InitializerView : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _pauseButton;
    
    public  ReactiveCommand<Unit> StartButtonPressed = new();
    public  ReactiveCommand<Unit> PauseButtonPressed = new();
    
    private void OnEnable()
    {
        _startButton.onClick.AddListener(() => StartButtonPressed.Execute(Unit.Default));
        _pauseButton.onClick.AddListener(() => PauseButtonPressed.Execute(Unit.Default));
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveAllListeners();
        _pauseButton.onClick.RemoveAllListeners();
    }
}
