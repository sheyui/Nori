using System;
using System.Collections.Generic;
using System.Text;

using CommunityToolkit.Mvvm.Messaging.Messages;
using Nori.Models;

namespace Nori.Messages;

public class TaskAddedMessage : ValueChangedMessage<TaskItem>
{
    public TaskAddedMessage(TaskItem task) : base(task)
    {
    }
}