using LanguageExt;
using MyMusic.Application.Read.Model;
using MyMusic.Application.Read.Ports;
using MyMusic.Application.SharedKernel.Model;

namespace MyMusic.Application.Queries {
    public class GetPlayListQuery {
        
        private readonly PlayListQueryPort playListQueryPort;
        
        public GetPlayListQuery(PlayListQueryPort playListQueryPort) {
            this.playListQueryPort = playListQueryPort;
        }

        public Either<Error, PlayList> Get(string playlistId) {
            return playListQueryPort.GetPlayList(playlistId);
        }
    }
}