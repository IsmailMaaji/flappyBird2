using UnityEngine;

public class loop_ground : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float width = 6f;
    private SpriteRenderer sr;
    private Vector2 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startPos = new Vector2(sr.bounds.min.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        sr.size = new Vector2(sr.size.x + speed * Time.deltaTime, sr.size.y);

        if (sr.size.x >= width * 2)
        {
            sr.size = new Vector2(width, sr.size.y);
        }
    }
}
