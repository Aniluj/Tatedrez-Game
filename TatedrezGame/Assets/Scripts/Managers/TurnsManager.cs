using UnityEngine;

public class TurnsManager : MonoBehaviour
{
    private ChessColor _currentPlayerTurn = ChessColor.Black;
    public ChessColor CurrentPlayerTurn => _currentPlayerTurn;

    public void EndTurn()
    {
        _currentPlayerTurn = _currentPlayerTurn == ChessColor.Black ? ChessColor.White : ChessColor.Black;
    }
}
