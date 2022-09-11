using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private GameLevelsUIController _UIController;

    private FinishController _finish;

    public FinishController finish { get => _finish; set => _finish = value; }

    public GameLevelsUIController UIController { get => _UIController; set => _UIController = value; }

    public Finish(FinishController finish)
    {
        _finish = finish;
    }
    
    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.TryGetComponent(out Player player))
        {
            _finish.DoEneble(true);
            _UIController.DisplayInfoGameOver();
            Time.timeScale = 0;
        }
    }
}
