using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int _melonCount = 0;

    [SerializeField]
    private Text melonCountText;
    
    // audio
    [SerializeField]
    private AudioSource melonSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon"))
        {
            Destroy(collision.gameObject);
            _melonCount++;
            melonCountText.text = "Points: " + _melonCount.ToString();
            melonSFX.Play();
        }
    }
}
