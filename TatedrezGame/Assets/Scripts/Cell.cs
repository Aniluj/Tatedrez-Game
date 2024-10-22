using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _cellSpriteRenderer;
    private CellData _cellData;
    
    public Vector2Int BoardPosition {get; private set;}

    public void Initialize(CellData cellData_v, int rowPosition_v, int columnPosition_v)
    {
        _cellData = cellData_v;
        SetNewSprite(_cellData.CellSprite);
        SetBoardPosition(rowPosition_v, columnPosition_v);
    }

    public void SetNewSprite(Sprite cellSprite_v)
    {
        _cellSpriteRenderer.sprite = cellSprite_v;
    }

    public void SetBoardPosition(int row_v, int column_v)
    {
        BoardPosition = new Vector2Int(column_v, row_v);
    }
}
