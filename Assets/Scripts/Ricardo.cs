using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ricardo
{
    public static class GameUtils
    {
        public static bool EntityChanged(EntityData oldData, Entity currentEntity)
        {
            if (oldData.position != currentEntity.position || oldData.health != currentEntity.health || oldData.attack != currentEntity.attack || oldData.speed != currentEntity.speed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void ApplyToAll<T>(List<T> list, Action<T> action)
        {
            if (list == null) return;
            foreach (var item in list)
                action(item);
        }
        public static List<TResult> TransformAll<T, TResult>(List<T> list, Func<T, TResult> function)
        {
            List<TResult> result = new();
            foreach (var item in list)
            {
                result.Add(function(item));
            }
            return result;
        }
        public static void TransformAllOut<T, TResult>(
            List<T> list,
            Func<T, TResult> function,
            out List<TResult> convertList)
        {
            convertList = new();
            foreach (var item in list)
            {
                convertList.Add(function(item));
            }
        }
        //public static void ApplyDamage<T>
        //    (T enemy, int damage)
        //    where T : Enemies
        //{
        //    enemy.ExcecuteEntity();
        //}
    }
}