using UnityEngine;

public class SelectableMarker : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _selectableMarkerSpriteRenderer;

    public void UpdateSelectableMarkerSprite(Sprite selectableMarkerSprite_v)
    {
        _selectableMarkerSpriteRenderer.sprite = selectableMarkerSprite_v;
    }
}
