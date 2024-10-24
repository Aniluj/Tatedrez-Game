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

    [SerializeField] private ChessPieceData _demoRookPieceData;
    [SerializeField] private RookPiece _demoWhiteRookPieceToTestFunctionality;

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
        _demoWhiteRookPieceToTestFunctionality.Initialize(_demoRookPieceData);
        _tatedrezBoard.Initialize(_tatedrezBoardData);
    }
}
