using UnityEngine;

public class ScreenBoundaries : MonoBehaviour
{

    public Camera main_camera;

    private Vector2 screenBounds;
    private float objectWitdh;
    private float objectHeight;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, main_camera.transform.position.z));
        objectWitdh = transform.GetComponentInChildren<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponentInChildren<SpriteRenderer>().bounds.extents.y;
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWitdh, screenBounds.x - objectWitdh);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }

}
