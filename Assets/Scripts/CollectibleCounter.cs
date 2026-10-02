using UnityEngine;
using TMPro;

public class CollectibleCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public GameResetter resetter;      // arrastra el objeto GameResetter
    public int totalCollectibles = 3;

    private int count = 0;

    void Start()
    {
        UpdateText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false); // antes: Destroy
            count++;
            UpdateText();

            if (count >= totalCollectibles)
                resetter.ShowVictory();
        }
    }

    public void ResetCount()
    {
        count = 0;
        UpdateText();
    }

    void UpdateText()
    {
        counterText.text = "collectibles: " + count;
    }
}
