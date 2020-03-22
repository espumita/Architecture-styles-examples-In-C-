using LanguageExt;
using MyMusic.Application.Ports;
using MyMusic.Application.Ports.Persistence;
using MyMusic.Application.Services.Errors;
using MyMusic.Application.Services.Successes;
using MyMusic.Domain.Events;

namespace MyMusic.Application.Services {
    public class AddImageUrlToPlayListService {
        
        private readonly PlayListPersistencePort playListPersistence;
        private readonly EventBusPort eventBus;

        public AddImageUrlToPlayListService(PlayListPersistencePort playListPersistence, EventBusPort eventBus) {
            this.playListPersistence = playListPersistence;
            this.eventBus = eventBus;
        }

        public Either<ServiceError, ServiceResponse> Execute(string playListId, string aNewImageUrL) {
            var playList = playListPersistence.GetPlayList(playListId);
            playList.AddImageUrl(aNewImageUrL);
            playListPersistence.Persist(playList);
            eventBus.Raise(new PlayListImageUrlHasChanged(playList.Id, playList.ImageUrl));
            return ServiceResponse.Success;
        }
    }
}