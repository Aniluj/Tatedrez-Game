using UnityEngine;

[CreateAssetMenu(fileName = "NewBoardData", menuName = "Tatedrez/BoardData")]
public class BoardData : ScriptableObject
{
    [SerializeField] private CellData _whiteCellData;
    [SerializeField] private CellData _blackCellData;
    [SerializeField] private int _amountOfRows;
    [SerializeField] private int _amountOfColumns;

    public CellData WhiteCellData => _whiteCellData;
    public CellData BlackCellData => _blackCellData;
    public int AmountOfRows => _amountOfRows;
    public int AmountOfColumns => _amountOfColumns;
}
