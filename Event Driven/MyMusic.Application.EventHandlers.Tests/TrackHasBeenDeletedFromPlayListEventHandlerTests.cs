using MyMusic.Application.Ports.Notifications;
using MyMusic.Domain.Events;
using NSubstitute;
using NUnit.Framework;

namespace MyMusic.Application.EventHandlers.Tests {

    public class TrackHasBeenDeletedFromPlayListEventHandlerTests {
        private TrackHasBeenDeletedFromPlayListEventHandler trackHasBeenDeletedFromPlayList;
        private TracksNotifierPort tracksNotifier;


        [SetUp]
        public void SetUp() {
            tracksNotifier = Substitute.For<TracksNotifierPort>();
            trackHasBeenDeletedFromPlayList = new TrackHasBeenDeletedFromPlayListEventHandler(tracksNotifier);
        }

        [Test]
        public void notify_track_has_removed_added_to_play_list() {
            var aTrackId = ATrack.Id;
            var aPlaylistId = APlaylist.Id;
            
            trackHasBeenDeletedFromPlayList.Handle(new TrackHasBeenDeletedFromPlayList(aTrackId, aPlaylistId));
            
            tracksNotifier.Received().NotifyTrackHasRemovedFromPlayList(aTrackId, aPlaylistId);
        }
    }
}