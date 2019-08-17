using UnityEngine;

[CreateAssetMenu]
public class CollectablesBrush : GridBrushBase
{
    public GameObject collectable;

    public void Paint(GridLayout gridLayout, Vector3Int position)
    {
        Paint(gridLayout, collectable, position);
    }

    public override void Paint(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
    {
        Instantiate(brushTarget, position, brushTarget.transform.rotation, brushTarget.transform);
    }
}
