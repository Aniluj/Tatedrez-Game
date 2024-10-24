using UnityEngine;

[CreateAssetMenu(fileName = "NewChessPieceData", menuName = "Tatedrez/ChessPieceData")]
public class ChessPieceData : ScriptableObject
{
    [SerializeField] private Sprite _chessPieceSprite;
    [SerializeField] private ChessColor _chessPieceColor;

    public ChessColor ChessPieceColor => _chessPieceColor;
    public Sprite ChessPieceSprite => _chessPieceSprite;
}
