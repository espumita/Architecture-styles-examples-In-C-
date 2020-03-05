using MyMusic.Application.Services;
using MyMusic.Infrastructure.Adapters;
using MyMusic.Infrastructure.Adapters.Http;
using MyMusic.Infrastructure.Adapters.Persistence;

namespace MyMusic.ServiceCreators {

    public class PlayListServiceCreator {
        public GetPlayListService CreateGetPlayListService() {
            var playListDatabaseAdapter = new PLayListPostgreSQLAdapter();
            return new GetPlayListService(playListDatabaseAdapter);
        }

        public CreatePlayListService CreateCreatePlayListService() {
            var pLayListDatabaseAdapter = new PLayListPostgreSQLAdapter();
            var musicCloudApiHttpAdapter = new PlayListSpotifyApiAdapter();
            var uniqueIdentifiersInMemoryAdapter = new UniqueIdentifiersInMemoryAdapter();
            return new CreatePlayListService(uniqueIdentifiersInMemoryAdapter, pLayListDatabaseAdapter, musicCloudApiHttpAdapter);
        }

        public ChangePlayListService CreateChangePlayListService() {
            var pLayListDatabaseAdapter = new PLayListPostgreSQLAdapter();
            var musicCloudApiHttpAdapter = new PlayListSpotifyApiAdapter();
            return new ChangePlayListService(pLayListDatabaseAdapter, musicCloudApiHttpAdapter);
        }

        public ArchivePlayListService CreateArchivePlayListService() {
            var pLayListDatabaseAdapter = new PLayListPostgreSQLAdapter();
            var musicCloudApiHttpAdapter = new PlayListSpotifyApiAdapter();
            return new ArchivePlayListService(pLayListDatabaseAdapter, musicCloudApiHttpAdapter);
        }
    }
}