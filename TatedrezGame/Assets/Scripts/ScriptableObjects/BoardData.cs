using UnityEngine;

[CreateAssetMenu(fileName = "NewBoardData", menuName = "Tatedrez/BoardData")]
public class BoardData : ScriptableObject
{
    [SerializeField] private CellData _whiteCellData;
    [SerializeField] private CellData _blackCellData;
    [SerializeField] private int _amountOfRows;
    [SerializeField] private int _amountOfColumns;

    private CellData WhiteCellData => _whiteCellData;
    private CellData BlackCellData => _blackCellData;

    public int AmountOfRows => _amountOfRows;
    public int AmountOfColumns => _amountOfColumns;

    public CellData GetCellData(ChessColor cellColor_v)
    {
        return cellColor_v == ChessColor.Black ? BlackCellData : WhiteCellData;
    }
}
