using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Draggable> draggableObjects;
    public float snapRange = 0.5f;
    public Animator YearAnimator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Draggable draggable in draggableObjects)
        {
            draggable.dragEndedCallback = OnDragEnded;
        }
    }

    // Update is called once per frame
    void OnDragEnded(Draggable draggable)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach (Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            if (closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            draggable.transform.localPosition = closestSnapPoint.localPosition;
        }
        
        CheckPuzzle(closestSnapPoint);
    }

    private void CheckPuzzle(Transform snapPoint)
    {
        bool isPuzzleCorrect = true;
        for (int i = 0; i < draggableObjects.Count; i++)
        {
            if (draggableObjects[i].transform.localPosition != draggableObjects[i].destinationSocket.localPosition)
            {
                isPuzzleCorrect = false;
                break;
            }
        }

        if (isPuzzleCorrect)
        {
            YearAnimator.enabled = true;
        }
    }
}
