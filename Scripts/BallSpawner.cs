using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    float spawnWait;
    public float startWait;
    public float waveWait;
    public int spawnernumber;

    void Start()
    {
        //Spawn Waves 
        StartCoroutine(SpawnWaves());
    }

    //Get spawner number to then spawn correct object and get random spawn timings
    IEnumerator SpawnWaves()
    {
        if(spawnernumber == 1) {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("Ball1"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }
        if (spawnernumber == 2)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("Ball2"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }
        if (spawnernumber == 3)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("Ball3"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }
        if (spawnernumber == 4)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("Ball4"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }
        if (spawnernumber == 5)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("Ball5"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }
        if (spawnernumber == 6)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("Ball6"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }
        if (spawnernumber == 7)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("Ball7"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }
        if (spawnernumber == 8)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("Ball8"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }
        if (spawnernumber == 9)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.5F, 3F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("Ball9"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }
        if (spawnernumber == 10)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.5F, 3F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("Ball10"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }
        if (spawnernumber == 11)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("Ball11"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }
        if (spawnernumber == 12)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("Ball12"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }


        if (spawnernumber == 1001)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("PowerUpRb"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }



        if (spawnernumber == 1002)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("PowerUpResize"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }

        if (spawnernumber == 1007)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("PowerUpResizeLarger"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }

        if (spawnernumber == 1008)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("PowerUpChangeMovmentSpeed"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }


        if (spawnernumber == 1003)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("PowerUpSpawnCount"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }

        if (spawnernumber == 1004)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("BigBall1"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }

        if (spawnernumber == 1005)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("BigBall1"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }

        if (spawnernumber == 1006)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    spawnWait = Random.Range(0.2F, 2F);
                    Vector3 spawnPosition = transform.position;
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Resources.Load("BigBall1"), spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }

    }

}
