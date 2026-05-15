using UnityEngine;
using UnityEngine.AI;

public class RandomWander : MonoBehaviour
{
    // 隨機亂逛的半徑範圍（以角色為中心，周圍幾公尺內找新起點）
    public float wanderRadius = 10f;
    // 走到目標後，要停頓幾秒再走下一個地方
    public float timer = 2f;

    private NavMeshAgent agent;
    private float currentTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentTimer = timer;
        SetRandomDestination();
    }

    void Update()
    {
        currentTimer += Time.deltaTime;

        // 當時間到了，或者角色已經快走到隨機的目的地時
        if (currentTimer >= timer || (!agent.pathPending && agent.remainingDistance < 0.5f))
        {
            SetRandomDestination();
            currentTimer = 0f; // 重設計時器
        }
    }

    void SetRandomDestination()
    {
        // 在半徑範圍內隨機抓一個球體內的 3D 坐標
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position; // 加上目前角色所在的位置

        NavMeshHit navHit;
        // 最關鍵的一行：拿這個隨機坐標去跟「藍色烘焙地圖」比對，找到地圖上最近的有效可行走點
        if (NavMesh.SamplePosition(randomDirection, out navHit, wanderRadius, NavMesh.AllAreas))
        {
            // 讓角色往這個藍色地圖上的合法坐標走過去
            agent.SetDestination(navHit.position);
        }
    }
}