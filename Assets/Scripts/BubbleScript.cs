using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    public float oxygenAmount = 10.0f;

    public Sprite[] bubbleSprites;

    public AK.Wwise.Event bubblePopEvent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set random sprite
        GetComponentInChildren<SpriteRenderer>().sprite = bubbleSprites[Random.Range(0, bubbleSprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") && OxygenOverlay.instance != null) {
            OxygenOverlay.instance.AddOxygen(oxygenAmount);
            bubblePopEvent.Post(other.gameObject);
            other.GetComponent<DiverController>().SetSpawnPoint();
            Destroy(gameObject);
        }
    }
}
