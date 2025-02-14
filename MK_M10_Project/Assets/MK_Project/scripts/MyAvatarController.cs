using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyAvatarController : MonoBehaviour
{
    public List<GameObject> myAvatars = new List<GameObject>();
    public List<string> myAvatarNames = new List<string>();

    public int currentAvatar = 0;

    public TMP_Text characterNameLabel;
    private int totalNumberOfAvatars;

    

    private void Start()
    {
        totalNumberOfAvatars = myAvatars.Count; // this will take the value of as many avatars exist in the list
        ShowAvatarByID(currentAvatar);
    }


    public void ShowAvatarByID(int avatarID)
    {
        // this function will be responsible to show or hide the correct avatar
        for (int i=0;  i< totalNumberOfAvatars; i++)
        {
            if (i == avatarID)
            {
                myAvatars[i].SetActive(true);
            } else
            {
                myAvatars[i].SetActive(false);
            }
        }

        characterNameLabel.text = myAvatarNames[avatarID].ToString();
    }


    public void ShowNextAvatar()
    {
        currentAvatar++;
        if (currentAvatar> totalNumberOfAvatars - 1)
        {
            currentAvatar = 0;
        }
        ShowAvatarByID(currentAvatar);
    }

    public void ShowPreviousAvatar()
    {
        currentAvatar--;
        if (currentAvatar < 0)
        {
            currentAvatar = totalNumberOfAvatars - 1;
        }

        ShowAvatarByID(currentAvatar);
    }


}
