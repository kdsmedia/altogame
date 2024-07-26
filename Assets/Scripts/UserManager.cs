using UnityEngine;
using UnityEngine.UI;

public class UserManager : MonoBehaviour
{
    public Image profileImage;
    public Sprite frameRed;
    public Sprite frameBlue;

    public void UpdateUserProfile(string team, Sprite profilePic)
    {
        profileImage.sprite = profilePic;

        if (team == "A")
        {
            profileImage.sprite = frameRed;
        }
        else if (team == "B")
        {
            profileImage.sprite = frameBlue;
        }
    }
}
