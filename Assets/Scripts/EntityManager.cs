using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class TurnData
{
    public List<EntityData> allEntities = new List<EntityData>();

    public TurnData(List<EntityData> entities)
    {
        allEntities = new List<EntityData>(entities);
    }
}
public class EntityManager : MonoBehaviour
{
    public List<Entity> allEntities = new List<Entity>();

    public CustomizedStack<TurnData> undoStack = new CustomizedStack<TurnData>();
    public CustomizedStack<TurnData> redoStack = new CustomizedStack<TurnData>();

    public TurnData currentState;

    public bool itChanged = true;
    private void Awake()
    {
        SaveTurn();
    }
    public void SaveTurn()
    {
        if (!itChanged)
        {
            return;
        }
        if (currentState != null)
        {
            undoStack.Push(currentState);
        }   
        List<EntityData> newTurnEntities = new List<EntityData>();
        foreach (Entity e in allEntities)
        {
            newTurnEntities.Add(new EntityData(e));
        }
        currentState = new TurnData(newTurnEntities);
        redoStack.Clear();
        itChanged = false;
        Debug.Log("Turno guardado.");
    }
    private void ApplyTurn(TurnData turn)
    {
        foreach (EntityData data in turn.allEntities)
        {
            Entity e = allEntities.Find(x => x.id == data.id);
            if (e != null)
            {
                e.ApplyData(data);
            }
        }
    }
    [Button]
    public void Prev()
    {
        if (itChanged)//Guarda antes de retroceder si hubo cambios
        {
            SaveTurn();
        }
        if (undoStack.Count > 0)
        {
            redoStack.Push(currentState);
            currentState = undoStack.PopCustomized();
            ApplyTurn(currentState);
            Debug.Log("Retrocediste un turno.");
        }
        else
        {
            Debug.Log("No hay turnos para retroceder.");
        }
    }
    [Button]
    public void Next()
    {
        if (itChanged) //Guarda antes de avanzar si hubo cambios
        {
            SaveTurn();
        }
        if (redoStack.Count > 0)
        {
            undoStack.Push(currentState);
            currentState = redoStack.PopCustomized();
            ApplyTurn(currentState);
            Debug.Log("Avanzaste un turno.");
        }
        else
        {
            Debug.Log("No hay turnos para avanzar.");
        }
    }
}
