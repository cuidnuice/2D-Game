using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] int rand;
    [SerializeField] int createCount = 10;
    [SerializeField] GameObject enemyPrefabs;
    [SerializeField] Transform  [ ] createPositions;

    [SerializeField] List<GameObject> enemyList;

    void Start()
    {
        enemyList.Capacity = 15;

        CreateUnit();

        StartCoroutine(CreateRoutine());
    }

    IEnumerator CreateRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.25f);

            GetListObject(Random.Range(0, createCount));
        }
    }

    public void CreateUnit()
    {
        for (int i = 0; i < createCount; i++)
        {
            // 게임 오브젝트를 생성시키는 함수
            GameObject unit = Instantiate(enemyPrefabs);

            unit.SetActive(false);

            enemyList.Add(unit);
        }
    }

    public void GetListObject(int select)
    {
        while (enemyList[select].activeSelf)
        {
            select = (select + 1) % createCount;
        }

        enemyList[select].SetActive(true);

        rand = Random.Range(0, createPositions.Length);

        enemyList[select].transform.position = createPositions[rand].position;
    }
}
