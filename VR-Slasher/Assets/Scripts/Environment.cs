using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform agent;

    private void OnEnable()
    {
        ResetEnvironment();
    }

    public void ResetEnvironment()
    {
        agent.transform.localPosition = RandomPositionPlayer();
        agent.transform.localEulerAngles = RandomRotationPlayer();

        float y = player.transform.position.y;
        player.transform.localPosition = RandomPosition(y);
    }

    public Vector3 RandomPosition(float y)
    {
        float x = Random.Range(-6.5f, 6.5f);
        float z = Random.Range(-6.5f, 6.5f);

        return new Vector3(x, y, z);
    }

    private Vector3 RandomPositionPlayer()
    {
        float x = Random.Range(-6.75f, 6.75f);
        float z = Random.Range(-6.75f, -1.25f);

        return new Vector3(x, 0.5f, z);
    }

    private Vector3 RandomRotationPlayer()
    {
        float y = Random.Range(0.0f, 360.0f);

        return new Vector3(0f, y, 0f);
    }
}
