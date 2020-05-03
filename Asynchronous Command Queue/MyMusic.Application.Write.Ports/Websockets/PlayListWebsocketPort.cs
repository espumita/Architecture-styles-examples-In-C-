using System.Threading.Tasks;
using MyMusic.Domain.Events;

namespace MyMusic.Application.Ports.Websockets {

    public interface WebsocketPort {
        Task PushMessageWithEvent(Event @event);
    }
}