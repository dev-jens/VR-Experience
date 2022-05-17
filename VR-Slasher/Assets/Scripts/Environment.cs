using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform agent;

    private List<Transform> players;

    private void OnEnable()
    {
        ResetEnvironment();
    }

    public void ResetEnvironment()
    {
        // Remove all players still in the field

        // Reset agent position
        do
        {
            agent.transform.localPosition = RandomPosition(.5f);
            agent.transform.localEulerAngles = RandomRotation();
        } while (Physics.CheckSphere(agent.transform.position, .1f));

        // Reset player (Agent's target) position
        for (int i = 0; i < 4; i++)
        {
            Transform player = Instantiate(playerPrefab, transform.parent).transform;
            players.Add(player);
            do
            {
                player.transform.position = RandomPosition(0.5f);
            } while (Physics.CheckSphere(player.transform.position, .1f));
        }
    }

    public Vector3 RandomPosition(float y)
    {
        float x = Random.Range(-9.25f, 9.25f);
        float z = Random.Range(-9.25f, 9.25f);

        return new Vector3(x, y, z);
    }

    private Vector3 RandomRotation()
    {
        float y = Random.Range(0.0f, 360.0f);

        return new Vector3(0f, y, 0f);
    }
}
