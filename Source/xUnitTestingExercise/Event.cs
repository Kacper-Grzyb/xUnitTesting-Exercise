using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvents
{
    public class Event
    {
        public string Name { get; }
        public string Type { get; }
        public int Capacity { get; private set; }
        public int maxCapacity { get; private set; }
        public bool IsActive { get; private set; }
        public int waitingList { get; private set; }  

        public Event(string name, string type, int capacity)
        {
            Name = name;
            Type = type;
            Capacity = capacity;
            maxCapacity = capacity;
            IsActive = true;
        }

        public void Cancel()
        {
            IsActive = false;
        }

        public bool RegisterAttendee()
        {
            if (IsActive && Capacity > 0)
            {
                Capacity--;
                return true;
            }
            else if(IsActive)
            {
                waitingList++;
                return true;
            }
            return false;
        }

        public bool RemoveAttendee()
        {
            if (Capacity == maxCapacity) return false;
            if(IsActive)
            {
                if(waitingList > 0 && Capacity == 0)
                {
                    waitingList--;
                    return true;
                }
                Capacity++;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string ans = $"{Name} of type {Type} has capacity for {Capacity} more People, and is currently ";
            string activeString = IsActive ? "active" : "inactive";
            ans += activeString;
            if (waitingList > 0) ans += $" with {waitingList} people on the Waiting List";
            return ans;
        }

    }
}
