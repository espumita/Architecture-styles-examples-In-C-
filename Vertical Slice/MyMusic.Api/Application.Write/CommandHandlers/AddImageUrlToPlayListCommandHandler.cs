using LanguageExt;
using MyMusic.Application.Write.Commands;
using MyMusic.Application.Write.Commands.Successes;
using MyMusic.Application.Write.Ports;
using MyMusic.Application.Write.Ports.Persistence;
using MyMusic.Domain.Error;

namespace MyMusic.Application.Write.CommandHandlers {
    public class AddImageUrlToPlayListCommandHandler {
        
        private readonly PlayListPersistencePort playListPersistence;
        private readonly EventPublisherPort eventPublisher;

        public AddImageUrlToPlayListCommandHandler(PlayListPersistencePort playListPersistence, EventPublisherPort eventPublisher) {
            this.playListPersistence = playListPersistence;
            this.eventPublisher = eventPublisher;
        }

        public Either<DomainError, CommandResult> Handle(ChangePlayListImageUrl command) {
            var playList = playListPersistence.GetPlayList(command.PlaylistId);
            playList.AddImageUrl(command.NewImageUrl);

            playListPersistence.Persist(playList);
            eventPublisher.Publish(playList.Events());
            return CommandResult.Success;
        }
    }
}