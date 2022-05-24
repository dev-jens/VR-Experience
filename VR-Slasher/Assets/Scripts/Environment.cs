using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform agent;

    [SerializeField] private GameObject ground;

    [SerializeField] private int targets;

    private List<GameObject> players = new List<GameObject>();

    public void ResetEnvironment()
    {
        // Remove all players still in the field
        foreach(var player in players)
        {
            Destroy(player.gameObject);
        }
        players.Clear();

        // Reset player (Agent's target) position
        for (int i = 0; i < targets; i++)
        {
            GameObject player = Instantiate(playerPrefab, transform.parent);
            player.transform.parent = transform;
            players.Add(player);
            do
            {
                player.transform.localPosition = RandomPosition(player.transform.localPosition.y);
            } while (Physics.CheckSphere(player.transform.localPosition, .1f));
        }

        // Reset agent position
        do
        {
            agent.transform.localPosition = RandomPosition(agent.transform.localPosition.y);
            agent.transform.localEulerAngles = RandomRotation();
        } while (Physics.CheckSphere(agent.transform.localPosition, .1f));

        // Give location of target to the agent
        agent.GetComponent<SeekerAgent>().Target = players[0];
    }

    public Vector3 RandomPosition(float y)
    {
        var maxX = (ground.transform.localScale.x / 2) - 0.75f;
        var maxY = (ground.transform.localScale.y / 2) - 0.75f;

        float x = Random.Range(-maxX, maxX);
        float z = Random.Range(-maxY, maxY);

        return new Vector3(x, y, z);
    }

    private Vector3 RandomRotation()
    {
        float y = Random.Range(0.0f, 360.0f);

        return new Vector3(0f, y, 0f);
    }
}
