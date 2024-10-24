using UnityEngine;

public class InputManager : MonoBehaviour
{
	private ChessPiece _currentlySelectedChessPiece;

    private void Update()
    {
		HandleInput();
	}

    private void HandleInput()
    {
		switch(GameManager.Instance.CurrentGameplayMode)
        {
			case GameplayMode.ClassicTicTacToeMode:
                {
					ClassicModeInputDetection();
					break;
				}
			case GameplayMode.DynamicTatedrezMode:
                {
					DynamicModeInputDetection();
					break;
				}
        }
	}

	private void ClassicModeInputDetection()
	{
		bool hasTouch = Input.GetMouseButtonUp(0);

		if (hasTouch)
		{
			Vector2 touchPos = Input.mousePosition;

			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touchPos), Vector2.zero);

			if (hit.collider != null)
			{
				ChessPiece pieceSelected = hit.collider.gameObject.GetComponent<ChessPiece>();

				if (pieceSelected != null && pieceSelected.ChessPieceData.ChessPieceColor == GameManager.Instance.TurnsManager.CurrentPlayerTurn)
				{
					_currentlySelectedChessPiece = pieceSelected;
					GameManager.Instance.TatedrezBoard.ShowSelectableCellsDisplay(_currentlySelectedChessPiece);
				}
			}
		}
	}

	private void DynamicModeInputDetection()
	{
		bool hasTouch = Input.GetMouseButtonUp(0);

		if (hasTouch)
		{
			Vector2 touchPos = Input.mousePosition;

			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touchPos), Vector2.zero);

			if (hit.collider != null)
			{
				ChessPiece pieceSelected = hit.collider.gameObject.GetComponent<ChessPiece>();

				if (pieceSelected != null && pieceSelected.ChessPieceData.ChessPieceColor == GameManager.Instance.TurnsManager.CurrentPlayerTurn)
				{
					_currentlySelectedChessPiece = pieceSelected;
					GameManager.Instance.TatedrezBoard.ShowSelectableCellsDisplay(_currentlySelectedChessPiece);
				}
			}
		}
	}
}