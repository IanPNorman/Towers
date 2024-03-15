using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCountDisplay : MonoBehaviour
{
    public GameObject cube; // Reference to the cube GameObject
    public TextMesh[] faceTexts; // Array to store TextMesh components for cube faces

    private int itemCount = 0; // item count to be displayed on all faces

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the cube and faceTexts references are set
        if (cube == null || faceTexts == null || faceTexts.Length == 0)
        {
            Debug.LogError("Cube or faceTexts reference is missing or empty.");
            enabled = false; // Disable the script if references are missing or empty
            return;
        }

        // Update the text on each face of the cube with the initial itemCount value
        updateAllFaceTexts();
    }


    // Update is called once per frame
    void Update()
    {
        // Update face texts if the item count has changed 
        if (hasItemCountChanged())
        {
            updateAllFaceTexts();
        }
    }

    void updateAllFaceTexts()
    {
        for (int i = 0; i < faceTexts.Length; i++)
        {
            faceTexts[i].text = itemCount.ToString();
        }
    }

    public void incrementItemCount()
    {
        itemCount++;
    }

    public void decrementItemCount()
    {
        itemCount--;
    }

    bool hasItemCountChanged()
    {
        if (int.Parse(faceTexts[0].text) != itemCount)
        {
            return true;
        }
        return false; 
    }
}
