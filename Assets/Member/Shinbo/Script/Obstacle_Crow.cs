using UnityEngine;

/// <summary>
/// 烏
/// </summary>
public class Obstacle_Crow : ObstacleController
{
    [SerializeField] float _decreaseSeconds = 1;

    public override void ObstacleCollision()
    {
        Timer.IncreaseTime(_decreaseSeconds);
        Debug.Log("烏に衝突");
    }
}
