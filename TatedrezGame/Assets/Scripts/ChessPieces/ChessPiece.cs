using System;
using System.Collections.Generic;
using UnityEngine;

public enum ChessColor
{
    White = 0,
    Black = 1
}

public abstract class ChessPiece : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer _chessPieceSpriteRenderer;
    protected ChessPieceData _chessPieceData;
    protected Vector2Int _boardPosition;
    public ChessPieceData ChessPieceData => _chessPieceData;
    public Vector2Int BoardPosition => _boardPosition;

    public abstract List<Vector2Int> GetAvailableMoves(Cell[,] boardCells_v);

    public virtual void Initialize(ChessPieceData chessPieceData_v)
    {
        _chessPieceData = chessPieceData_v;
        SetNewSprite(chessPieceData_v.ChessPieceSprite);
    }

    protected void SetNewSprite(Sprite _chessPieceNewSprite)
    {
        _chessPieceSpriteRenderer.sprite = _chessPieceNewSprite;
    }

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

    public virtual void Place(Cell cellToTake_v, Action onFinishPlacement_v = null)
    {
        _boardPosition = cellToTake_v.BoardPosition;
        transform.position = cellToTake_v.transform.position;

        onFinishPlacement_v?.Invoke();
    }

    protected bool IsWithinBounds(Vector2Int finalPosition_v, Vector2Int boardSize_v)
    {
        return finalPosition_v.x >= 0 && finalPosition_v.x < boardSize_v.x && finalPosition_v.y >= 0 && finalPosition_v.y < boardSize_v.y;
    }
}