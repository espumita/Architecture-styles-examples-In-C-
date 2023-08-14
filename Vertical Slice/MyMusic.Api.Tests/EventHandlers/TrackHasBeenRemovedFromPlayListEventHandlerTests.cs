using System.Threading.Tasks;
using MyMusic.Application.Write.EventHandlers;
using MyMusic.Application.Write.Ports.Notifications;
using MyMusic.Application.Write.Ports.Websockets;
using MyMusic.Events;
using NSubstitute;
using NUnit.Framework;

namespace MyMusic.Api.Tests.EventHandlers {

    public class TrackHasBeenRemovedFromPlayListEventHandlerTests {
        private TrackHasBeenRemovedFromPlayListEventHandler trackHasBeenRemovedFromPlayList;
        private TracksNotifierPort tracksNotifier;
        private WebsocketPort websocketPort;


        [SetUp]
        public void SetUp() {
            tracksNotifier = Substitute.For<TracksNotifierPort>();
            websocketPort = Substitute.For<WebsocketPort>();
            trackHasBeenRemovedFromPlayList = new TrackHasBeenRemovedFromPlayListEventHandler(tracksNotifier, websocketPort);
        }

        [Test]
        public async Task notify_track_has_removed_added_to_play_list_and_send_to_websocket() {
            var aTrackId = ATrack.Id;
            var aPlaylistId = APlaylist.Id;
            var @event = new TrackHasBeenRemovedFromPlayList(aTrackId, aPlaylistId);

            await trackHasBeenRemovedFromPlayList.Handle(@event);
            
            tracksNotifier.Received().NotifyTrackHasRemovedFromPlayList(aTrackId, aPlaylistId);
            await websocketPort.Received().PushMessageWithEventToAll(@event);
        }
    }
}