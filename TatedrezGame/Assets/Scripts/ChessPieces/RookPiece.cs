using System.Collections.Generic;
using UnityEngine;

public class RookPiece : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves(Cell[,] boardCells_v)
    {
        List<Vector2Int> availableMoves = new List<Vector2Int>();

        switch (GameManager.Instance.CurrentGameplayMode)
        {
            case GameplayMode.ClassicTicTacToeMode:
                {
                    availableMoves =  GetClassicTicTacToeMoves(boardCells_v);
                    break;
                }
            case GameplayMode.DynamicTatedrezMode:
                {
                    int rowSize = boardCells_v.GetLength(0);
                    int columnSize = boardCells_v.GetLength(1);

                    for (int row = _boardPosition.y + 1; row < rowSize; row++)
                    {
                        if (!AddMoveOrStop(row, _boardPosition.x, boardCells_v, availableMoves)) break;
                    }
                    for (int row = _boardPosition.y - 1; row >= 0; row--)
                    {
                        if (!AddMoveOrStop(row, _boardPosition.x, boardCells_v, availableMoves)) break;
                    }

                    for (int column = _boardPosition.x + 1; column < columnSize; column++)
                    {
                        if (!AddMoveOrStop(_boardPosition.y, column, boardCells_v, availableMoves)) break;
                    }
                    for (int column = _boardPosition.x - 1; column >= 0; column--)
                    {
                        if (!AddMoveOrStop(_boardPosition.y, column, boardCells_v, availableMoves)) break;
                    }

                    break;
                }
        }

        return availableMoves;
    }

    private bool AddMoveOrStop(int column_v, int row_v, Cell[,] boardCells_v, List<Vector2Int> availableMoves)
    {
        Vector2Int newMove = new Vector2Int(row_v, column_v);
        Vector2Int boardSize = new Vector2Int(boardCells_v.GetLength(0), boardCells_v.GetLength(1));

        if (IsWithinBounds(newMove, boardSize))
        {
            if (!boardCells_v[row_v, column_v].HasLocker)
            {
                availableMoves.Add(newMove);
                return true;
            }

            return false;
        }

        return false;
    }
}