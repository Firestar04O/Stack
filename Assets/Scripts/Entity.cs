using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ricardo;

public class EntityData
{
    public int id;
    public int health;
    public int attack;
    public float speed;
    public Vector2 position;

    public EntityData(Entity entity)
    {
        id = entity.id;
        health = entity.health;
        attack = entity.attack;
        speed = entity.speed;
        position = entity.position;
    }
}
public class Entity : MonoBehaviour
{
    public int id;
    public int health;
    public int attack;
    public float speed;
    public Vector2 position;
    public EntityManager manager;
    private void Update()
    {
        position = transform.position;
    }
    public void ModifyEntity(Entity modifiedEntity)
    {
        if (manager.currentState == null)
        {
            return;
        }
        EntityData savedData = manager.currentState.allEntities.Find(data => data.id == id);
        if (savedData != null && Ricardo.GameUtils.EntityChanged(savedData, this))
        {
            manager.itChanged = true;
        }
    }
    public void ApplyData(EntityData data)
    {
        health = data.health;
        attack = data.attack;
        speed = data.speed;
        transform.position = data.position;
        //position = data.position;
    }
}
