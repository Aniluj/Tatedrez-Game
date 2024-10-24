using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;
    private BoardData _boardData;
    private Cell[,] _cells;
    private List<ChessPiece> _placedPieces = new List<ChessPiece>();
    private const int _cellSize = 1;

    public void Initialize(BoardData boardData_v)
    {
        _boardData = boardData_v;
        _cells = new Cell[_boardData.AmountOfRows, _boardData.AmountOfColumns];
        CreateCenteredCells();
    }

    public void CreateCenteredCells()
    {
        float totalWidth = _boardData.AmountOfColumns * _cellSize;
        float totalHeight = _boardData.AmountOfRows * _cellSize;

        float startX = -((totalWidth - _cellSize) / 2f);
        float startY = ((totalHeight - _cellSize) / 2f);

        ChessColor lastCellColorUsed = (ChessColor)Random.Range(0, 2);

        for (int row = 0; row < _boardData.AmountOfRows; row++)
        {
            for (int column = 0; column < _boardData.AmountOfColumns; column++)
            {
                Vector3 cellPosition = new Vector3(startX + (column * _cellSize), startY - (row * _cellSize));

                var cell = Instantiate(_cellPrefab, cellPosition, Quaternion.identity, transform);
                cell.name = $"Cell_{row}_{column}";

                lastCellColorUsed = lastCellColorUsed == ChessColor.Black ? ChessColor.White : ChessColor.Black;

                cell.Initialize(_boardData.GetCellData(lastCellColorUsed), row, column);
                _cells[row, column] = cell;
            }
        }
    }

    public void ShowSelectableCellsDisplay(ChessPiece selectedChessPiece_v)
    {
        var availableMoves = selectedChessPiece_v.GetAvailableMoves(_cells);

        if (availableMoves != null && availableMoves.Count > 0)
        {
            for (int i = 0; i < availableMoves.Count; i++)
            {
                _cells[availableMoves[i].x, availableMoves[i].y].SwitchSelectabilityDisplay(true);
            }
        }
    }

    public void ChangeCellSelectableDisplayStates(bool isEnable)
    {
        foreach (Cell cell in _cells)
        {
            if (!cell.HasLocker) cell.SwitchSelectabilityDisplay(isEnable);
        }
    }
}
