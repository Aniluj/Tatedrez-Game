using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _cellSpriteRenderer;
    [SerializeField] private SelectableMarker _selectableMarker;
    private CellData _cellData;
    private ChessPiece _pieceLocker;
    
    public Vector2Int BoardPosition {get; private set;}
    public bool HasLocker => _pieceLocker != null;

    public void Initialize(CellData cellData_v, int rowPosition_v, int columnPosition_v)
    {
        _cellData = cellData_v;
        SetNewSprite(_cellData.CellSprite);
        SetBoardPosition(rowPosition_v, columnPosition_v);
        _selectableMarker.UpdateSelectableMarkerSprite(cellData_v.SelectableMarkerSprite);
    }

    public void SetNewSprite(Sprite cellSprite_v)
    {
        _cellSpriteRenderer.sprite = cellSprite_v;
    }

    public void SetBoardPosition(int row_v, int column_v)
    {
        BoardPosition = new Vector2Int(column_v, row_v);
    }

    public void Lock(ChessPiece pieceLocker_v)
    {
        _pieceLocker = pieceLocker_v;
    }

    public void SwitchSelectabilityDisplay(bool isAvailable)
    {
        _selectableMarker.gameObject.SetActive(isAvailable);
    }
}
