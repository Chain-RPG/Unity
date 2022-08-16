using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessingQueue
{
    static ProcessingQueue processor;
    public static ProcessingQueue Processor { get { init(); return processor; } }

    Queue<Action> queue = new Queue<Action>();
    object _lock = new object();

    static void init()
    {
        if (processor == null)
        {
            processor = new ProcessingQueue();
        }
    }

    public void Push(Action action)
    {
        lock (_lock)
        {
            queue.Enqueue(action);
        }
    }

    public void Flush()
    {
        lock (_lock)
        {
            while(queue.Count > 0)
            {
                Action action = queue.Dequeue();
                action.Invoke();
            }
        }
    }
}
