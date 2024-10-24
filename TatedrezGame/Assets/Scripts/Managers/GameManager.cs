using UnityEngine;

public enum GameplayMode
{ 
    ClassicTicTacToeMode = 0,
    DynamicTatedrezMode = 1
}

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    [SerializeField] private Board _tatedrezBoard;
    [SerializeField] private BoardData _tatedrezBoardData;
    [SerializeField] private TurnsManager _turnsManager;

    public static GameManager Instance => _instance;
    public TurnsManager TurnsManager => _turnsManager;
    public Board TatedrezBoard => _tatedrezBoard;
    public GameplayMode CurrentGameplayMode { get; private set; }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        CurrentGameplayMode = GameplayMode.ClassicTicTacToeMode;
        _tatedrezBoard.Initialize(_tatedrezBoardData);
    }
}
