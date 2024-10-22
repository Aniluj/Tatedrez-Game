using UnityEngine;

[CreateAssetMenu(fileName = "NewCellData", menuName = "Tatedrez/CellData")]
public class CellData : ScriptableObject
{
    [SerializeField] private ChessColor _cellColor;
    [SerializeField] private Sprite _cellSprite;

    public ChessColor CellColor => _cellColor;
    public Sprite CellSprite => _cellSprite;
}
