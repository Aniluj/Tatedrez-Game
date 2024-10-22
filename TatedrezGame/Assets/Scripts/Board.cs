using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private BoardData _boardData;
    private Cell[,] _cells;
    private const int _cellSize = 1;

    private void Start()
    {
        Initialize(_boardData);
    }

    public void Initialize(BoardData boardData_v)
    {
        _boardData = boardData_v;
        _cells = new Cell[_boardData.AmountOfRows, _boardData.AmountOfColumns];
        CreateCenteredCells();
    }

    public void CreateCenteredCells()
    {
        float offsetX = -(((_boardData.AmountOfColumns * _cellSize) - _cellSize) / 2f);
        float offsetY = (((_boardData.AmountOfRows * _cellSize) - _cellSize) / 2f);
        ChessColor lastCreatedCellColor = (ChessColor)Random.Range(0, 1);

        for (int row = 0; row < _boardData.AmountOfRows; row++)
        {
            for (int column = 0; column < _boardData.AmountOfColumns; column++)
            {
                Vector3 cellPosition = new Vector3(offsetX + (column * _cellSize), offsetY - (row * _cellSize));

                var cell = Instantiate(_cellPrefab, cellPosition, Quaternion.identity, transform);
                cell.name = $"Cell_{row}_{column}";

                if (lastCreatedCellColor == ChessColor.White)
                {
                    cell.Initialize(_boardData.BlackCellData, row, column);
                    _cells[row, column] = cell;
                    lastCreatedCellColor = ChessColor.Black;
                }
                else
                {
                    cell.Initialize(_boardData.WhiteCellData, row, column);
                    _cells[row, column] = cell;
                    lastCreatedCellColor = ChessColor.White;
                }
            }
        }
    }
}
