using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text messageText;
    public AudioSource audioSource;
    public AudioClip[] giftSounds;

    public void PlayGiftSound(int giftAmount)
    {
        AudioClip clip = null;
        switch (giftAmount)
        {
            case 1:
                clip = giftSounds[0];
                break;
            case 5:
                clip = giftSounds[1];
                break;
            case 10:
                clip = giftSounds[2];
                break;
            case 20:
                clip = giftSounds[3];
                break;
            case 30:
                clip = giftSounds[4];
                break;
            case 100:
                clip = giftSounds[5];
                break;
        }

        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
    }
}
