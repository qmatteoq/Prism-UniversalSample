using Microsoft.Practices.Prism.PubSubEvents;
using Prism_Messages.Entities;

namespace Prism_Messages.Events
{
    public class AddPersonEvent : PubSubEvent<Person>
    {
    }
}
