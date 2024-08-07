using UnityEngine;

/// <summary>
/// 飛行機
/// </summary>
public class Obstacle_Airplane : ObstacleController
{

    [SerializeField] float _decreaseSeconds = 3;
    public override void ObstacleCollision()
    {
        Timer.IncreaseTime(_decreaseSeconds);
        Debug.Log("飛行機に衝突");
    }
}
