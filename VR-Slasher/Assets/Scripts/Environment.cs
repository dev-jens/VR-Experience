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
        // Reset agent position
        do
        {
            agent.transform.localPosition = RandomPosition(.5f);
            agent.transform.localEulerAngles = RandomRotation();
        } while (Physics.CheckSphere(agent.transform.position, .1f));

        // Reset player (Agent's target) position
        do
        {
            player.transform.localPosition = RandomPosition(.5f);
        } while (Physics.CheckSphere(player.transform.position, .1f));
    }

    public Vector3 RandomPosition(float y)
    {
        float x = Random.Range(-14.25f, 14.25f);
        float z = Random.Range(-14.25f, 14.25f);

        return new Vector3(x, y, z);
    }

    private Vector3 RandomRotation()
    {
        float y = Random.Range(0.0f, 360.0f);

        return new Vector3(0f, y, 0f);
    }
}
