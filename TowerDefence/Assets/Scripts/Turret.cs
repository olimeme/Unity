using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Shooting settings")]
    [SerializeField]
    private Bullet bulletPrefab;
    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private float fireRate;
    private float fireCountdown = 0;

    [SerializeField]
    private float radius;

    [Header("Rotation settings")]

    [SerializeField]
    private Transform partToRotate;

    [SerializeField]
    private float speed;

    private Transform target;
    private List<Transform> enemies = new List<Transform>();

    private void Start(){
        InvokeRepeating("CheckTarget", 0f, 0.3f);
    }

    private void Update(){
        if(target == null)
            return;
        Rotate();

        if(fireCountdown <= 0){
            Shoot();
            // кол-во снарядов за единицу времени
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    private void Shoot(){
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.Seek(target);
    }

    private void CheckTarget(){
        // получаем всех врагов, находящихся на карте
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // создаем переменную для поиска наименьшей дистанции и даем ей максимальное значение
        float shortestDistance = Mathf.Infinity;
        // создаем переменную для объекта, который ближе всего к турели
        GameObject nearestEnemy = null;
        
        // проходим весь массив врагов
        foreach (GameObject enemy in enemies){
            // замеряем дистанцию до каждого из них
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            // постоянно обновляем значение дистанции
            if (distanceToEnemy < shortestDistance){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
         // если удалось найти самого ближайшего противника и он в зоне поражения
        if (nearestEnemy != null && shortestDistance <= radius){
            // этот объект является целью турели
            target = nearestEnemy.transform;
        }
        else{
            // цель равна null, цели нет
            target = null;
        }
    }

    private void Rotate(){
        var direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        var rotation = Quaternion.Lerp(
            partToRotate.rotation, 
            lookRotation, 
            Time.deltaTime * speed
        ).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
