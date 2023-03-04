using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 2f; //enemy?????? ???? ???? 5?????? ????
    public Text enemycount;
    public Text wow;
    public static int ene = 0;//???? ????


    private float countdown = 2f;  //?????? 2?????? ??????????

    private int waveIndex = 0;

    // 5??????(???? ????)SpawnWave() ????????
    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());

            countdown = timeBetweenWaves; //countdown ?? enemy?????? ???? ????
            return;

        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity); //setTime???? 0f???? ?????? 0f??, Mathf.?????????? ???? Mathf.?????? ????
        enemycount.text = string.Format("{000}", countdown);
        enemycount.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave() //?????? ???? ??????
    {
        //WaveSpawner.EnemiesAlive++;
        /*Wave wave = waves[waveIndex];
        SpawnEnemy(wave.enemy);
        ene++; //???? ????
        waveIndex++;
        yield return new WaitForSeconds(0.1f); *///1?? ?? ???? ?????????? ????????
       
        if ( ene<=19) // ene?? 19???? ?????? ???? ????
        {
            
            wow.text = "Stage 1"; // ???????? ????????1 ?? ????
            //Wave wave = waves[waveIndex];
            Wave wave = waves[waveIndex]; //?????? ???????? ????
            SpawnEnemy(wave.enemy); // ??????
            ene++; //???? ????
            waveIndex++;//???????? ????
            while(ene >= 20) // ene?? 20???? ?????? ???? ????
            {
                yield return new WaitForSeconds(10f);// ?? 10??? ?????? ????
                while (ene <= 39) //ene?? 39???? ?????? ????????
                {
                    wave = waves[waveIndex]; //wave?? wave?????????? ???? ????.
                    wow.text = "Stage 2";// ???????? ????????2?? ????
                    SpawnEnemy(wave.enemy); // ??????
                    ene++; //???? ????
                    waveIndex++; // ???????? ????
                    yield return new WaitForSeconds(1.2f); //?????? ??????

                    while (ene >= 40)// ene ?? 40???? ?????? ????????
                    {
                        yield return new WaitForSeconds(10f); // ?? 10??? ?????? ????
                        while (ene <= 59) //?? ???? ????...
                        {
                            wave = waves[waveIndex];
                            wow.text = "Stage 3";
                            SpawnEnemy(wave.enemy);
                            ene++; //???? ????
                            waveIndex++;
                            yield return new WaitForSeconds(1.2f);
                            while (ene >= 60)
                            {
                                yield return new WaitForSeconds(10f);
                                while (ene <= 79)
                                {
                                    wave = waves[waveIndex];
                                    wow.text = "Stage 4";
                                    SpawnEnemy(wave.enemy);
                                    ene++; //???? ????
                                    waveIndex++;
                                    yield return new WaitForSeconds(1.2f);
                                    while (ene >= 80)
                                    {
                                        yield return new WaitForSeconds(10f);
                                        while (ene <= 99)
                                        {
                                            wave = waves[waveIndex];
                                            wow.text = "Stage 5";
                                            SpawnEnemy(wave.enemy);
                                            ene++; //???? ????
                                            waveIndex++;
                                            yield return new WaitForSeconds(1.2f);
                                            while (ene >= 100)
                                            {
                                                yield return new WaitForSeconds(10f);
                                                while (ene <= 119)
                                                {
                                                    wave = waves[waveIndex];
                                                    wow.text = "Stage 6";
                                                    SpawnEnemy(wave.enemy);
                                                    ene++; //???? ????
                                                    waveIndex++;
                                                    yield return new WaitForSeconds(1.2f);
                                                    while (ene >= 120)
                                                    {
                                                        yield return new WaitForSeconds(10f);
                                                        while (ene <= 120)
                                                        {
                                                            wave = waves[waveIndex];
                                                            wow.text = "M Boss";
                                                            SpawnEnemy(wave.enemy);
                                                            ene++; //???? ????
                                                            waveIndex++;
                                                            yield return new WaitForSeconds(1.2f);
                                                            while (ene >= 121)
                                                            {
                                                                yield return new WaitForSeconds(10f);
                                                                while (ene <= 139)
                                                                {
                                                                    wave = waves[waveIndex];
                                                                    wow.text = "Stage 7";
                                                                    SpawnEnemy(wave.enemy);
                                                                    ene++; //???? ????
                                                                    waveIndex++;
                                                                    yield return new WaitForSeconds(1.2f);
                                                                    while (ene >= 140)
                                                                    {
                                                                        yield return new WaitForSeconds(10f);
                                                                        while (ene <= 159)
                                                                        {
                                                                            wave = waves[waveIndex];
                                                                            wow.text = "Stage 8";
                                                                            SpawnEnemy(wave.enemy);
                                                                            ene++; //???? ????
                                                                            waveIndex++;
                                                                            yield return new WaitForSeconds(1.2f);
                                                                            while (ene >= 160)
                                                                            {
                                                                                yield return new WaitForSeconds(10f);
                                                                                while (ene <= 179)
                                                                                {
                                                                                    wave = waves[waveIndex];
                                                                                    wow.text = "Stage 9";
                                                                                    SpawnEnemy(wave.enemy);
                                                                                    ene++; //???? ????
                                                                                    waveIndex++;
                                                                                    yield return new WaitForSeconds(1.2f);
                                                                                    while (ene >= 180)
                                                                                    {
                                                                                        yield return new WaitForSeconds(10f);
                                                                                        while (ene <= 199)
                                                                                        {
                                                                                            wave = waves[waveIndex];
                                                                                            wow.text = "Stage 10";
                                                                                            SpawnEnemy(wave.enemy);
                                                                                            ene++; //???? ????
                                                                                            waveIndex++;
                                                                                            yield return new WaitForSeconds(1.2f);
                                                                                            while (ene >= 200)
                                                                                            {
                                                                                                yield return new WaitForSeconds(10f);
                                                                                                while (ene <= 219)
                                                                                                {
                                                                                                    wave = waves[waveIndex];
                                                                                                    wow.text = "Stage 11";
                                                                                                    SpawnEnemy(wave.enemy);
                                                                                                    ene++; //???? ????
                                                                                                    waveIndex++;
                                                                                                    yield return new WaitForSeconds(1.2f);
                                                                                                    while (ene >= 220)
                                                                                                    {
                                                                                                        yield return new WaitForSeconds(10f);
                                                                                                        while (ene <= 239)
                                                                                                        {
                                                                                                            wave = waves[waveIndex];
                                                                                                            wow.text = "Stage 12";
                                                                                                            SpawnEnemy(wave.enemy);
                                                                                                            ene++; //???? ????
                                                                                                            waveIndex++;
                                                                                                            yield return new WaitForSeconds(1.2f);
                                                                                                            while (ene >= 240)
                                                                                                            {
                                                                                                                yield return new WaitForSeconds(10f);
                                                                                                                while (ene <= 259)
                                                                                                                {
                                                                                                                    wave = waves[waveIndex];
                                                                                                                    wow.text = "Stage 13";
                                                                                                                    SpawnEnemy(wave.enemy);
                                                                                                                    ene++; //???? ????
                                                                                                                    waveIndex++;
                                                                                                                    yield return new WaitForSeconds(1.2f);
                                                                                                                    while (ene >= 260)
                                                                                                                    {
                                                                                                                        yield return new WaitForSeconds(10f);
                                                                                                                        while (ene <= 260)
                                                                                                                        {
                                                                                                                            wave = waves[waveIndex];
                                                                                                                            wow.text = "Last Boss";
                                                                                                                            SpawnEnemy(wave.enemy);
                                                                                                                            ene++; //???? ????
                                                                                                                            waveIndex++;
                                                                                                                            yield return new WaitForSeconds(30f);

                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
        }
       
        
        if (ene == 60)
        {
            wow.text = "Stage 4";
        }
        if (ene == 80)
        {
            wow.text = "Stage 5";
        }
        if (ene == 100)
        {
            wow.text = "Stage 6";
        }
        if (ene == 120)
        {
            wow.text = "M Boss";
            
        }
        if (ene == 140)
        {
            wow.text = "Stage 7";
        }
        if (ene == 160)
        {
            wow.text = "Stage 8";
        }
        if (ene == 180)
        {
            wow.text = "Stage 9";
        }
        if (ene == 200)
        {
            wow.text = "Stage 10";
        }
        if (ene == 220)
        {
            wow.text = "Stage 11";
        }
        if (ene == 240)
        {
            wow.text = "Stage 12";
        }
        if (ene == 260)
        {
            wow.text = "Stage 13";
        }
        if (ene == 280)
        {
            wow.text = "FINAL";

           
        }
       
       
        if (waveIndex == waves.Length)//?????????? ??????
        {

        }

    }

    // ?????? (???????? ??????)
    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);


    }


}
