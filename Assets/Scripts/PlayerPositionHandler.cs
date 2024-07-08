using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionHandler : MonoBehaviour
{
    [SerializeField] Vector2 playerCurrentPosition;

    public Vector2 currentCheckpointPosition;

    public TransformData playerPositionData;

    private TriggerEvent playerTriggerEvent;
   

    void Start()
    {
        playerTriggerEvent = GetComponent<TriggerEvent>();
        currentCheckpointPosition = new Vector2(-10f , 1f);
    }

    #region Condition

    public void OnCheckpoint(GameObject col)
    {
        Vector2 newCheckpointPosition = col.transform.position;
        currentCheckpointPosition = newCheckpointPosition;
        SavePos(currentCheckpointPosition);
    }
    public void OnTrap()
    {
        ChangePlayerPosition(currentCheckpointPosition);
    }

    public void OnFinish()
    {
        playerPositionData.ResetData();
        Debug.Log("Udah, Finish!");
        GameManager.Instance.ChangeScene(0);
        GameManager.Instance.ChangeLevel(1);
    }

    #endregion

    private void ChangePlayerPosition(Vector2 newPosition)
    {
        transform.position = newPosition;  
    }

    #region SaveLoad

        private void LoadPos()
        {
            playerCurrentPosition = playerPositionData.position;
        }

        private void SavePos(Vector2 newPosition)
        {
            playerPositionData.position = newPosition;
        }

    #endregion
}
