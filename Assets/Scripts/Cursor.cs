using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    public GameObject placeObject;
    public float placeInterval = 10f;
    public Image placeGauge;
    public Text placeIntervalText;

    int layerMask;
    float timeEapsed;

    void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("Stage");
        timeEapsed = placeInterval;
    }

    void Update()
    {
        if (timeEapsed <= placeInterval)
        {
            timeEapsed += Time.deltaTime;
            placeGauge.fillAmount = timeEapsed / placeInterval;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        placeIntervalText.text = $"{placeInterval:f1}s";

        if (Physics.Raycast(ray, out hit, 64f, layerMask))
        {
            var hitPos = hit.transform.position;
            hitPos.y += 0.5f;
            var hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("Stage") && hit.normal.y > 0.9f)
            {
                this.transform.position = hitPos;
                if (Input.GetMouseButtonDown(0) && timeEapsed >= placeInterval)
                {
                    Instantiate(placeObject, hitPos, Quaternion.identity);
                    timeEapsed = 0f;
                }
            }

        }
    }
}
