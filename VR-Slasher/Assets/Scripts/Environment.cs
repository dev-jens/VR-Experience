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
        agent.transform.localPosition = new Vector3(0f, 0.5f, -4f);
        agent.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

        float y = player.transform.position.y;
        player.transform.position = RamdomPosition(y);
    }

    public Vector3 RamdomPosition(float y)
    {
        float x = Random.Range(-4.5f, 4.5f);
        float z = Random.Range(-4.5f, 4.5f);

        return new Vector3(x, y, z);
    }
}
