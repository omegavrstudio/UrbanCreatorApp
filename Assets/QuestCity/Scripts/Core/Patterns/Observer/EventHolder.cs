using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace QuestCity.Core.Patterns
{
    public static class EventHolder<T> where T : class
    {
        private static readonly List<Action<T>> _listeners = new List<Action<T>>();

        private static T _currentInfoState;

        public static void AddListeneer(Action<T> listener, bool instantNotify)
        {
            _listeners.Add(listener);
            if (instantNotify && _currentInfoState != null)
            {
                listener?.Invoke(_currentInfoState);
            }
        }

        public static void RaiseRegistraionInfo(T state)
        {
            _currentInfoState = state;

            foreach (var listener in _listeners)
            {
                listener?.Invoke(state);
            }

        }

        public static void RemoveListener(Action<T> listener)
        {
            if (!_listeners.Contains(listener))
            {
                _listeners.Remove(listener);
            }
        }
    }
}