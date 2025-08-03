using UnityEngine;

public class Cheats : MonoBehaviour
{
    [SerializeField] private Actor player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            EnemyActor.canBeCalled = false;
            LevelManager.instance.NextLevel();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (player.isImmortal)
            {
                player.isImmortal = false;

            }
            else
            {
                player.isImmortal = true;

            }
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Time.timeScale += 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Time.timeScale -= 0.5f;

            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 100f);
        }
    }
}
