using UnityEngine;

public class ScoreObject : MonoBehaviour
{

    private GameObject cursorObject;
    private Cursor cursorComponent;

    void Start()
    {
        cursorObject = GameObject.Find("Cursor");
        if (!cursorObject) return;
        cursorComponent = cursorObject.GetComponent<Cursor>();
    }

    void OnMouseEnter()
    {
        Collect();
    }

    void OnMouseOver()
    {
        Collect();
    }

    private void Collect()
    {
        if (!cursorComponent) return;
        cursorComponent.placeInterval *= 0.95f;
        Destroy(this.gameObject);
    }
}
