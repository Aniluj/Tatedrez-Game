using System.Collections.Generic;
using UnityEngine;

public enum ChessColor
{
    White = 0,
    Black = 1
}

public abstract class ChessPiece : MonoBehaviour
{
    protected ChessPieceData _chessPieceData;
    protected Vector2Int _boardPosition;
    public ChessPieceData ChessPieceData => _chessPieceData;
    public Vector2Int BoardPosition => _boardPosition;

    public abstract List<Vector2Int> GetAvailableMoves(Cell[,] boardCells_v);

    protected List<Vector2Int> GetClassicTicTacToeMoves(Cell[,] boardCells_v)
    {
        List<Vector2Int> availableMoves = new List<Vector2Int>();

        foreach (Cell cell in boardCells_v)
        {
            if (cell.HasLocker)
            {
                continue;
            }
            else
            {
                availableMoves.Add(cell.BoardPosition);
            }
        }

        return availableMoves;
    }

    public virtual void Initialize(ChessPieceData chessPieceData_v)
    {
        _chessPieceData = chessPieceData_v;
    }

    protected bool IsWithinBounds(Vector2Int finalPosition_v, Vector2Int boardSize_v)
    {
        return finalPosition_v.x >= 0 && finalPosition_v.x < boardSize_v.x && finalPosition_v.y >= 0 && finalPosition_v.y < boardSize_v.y;
    }
}