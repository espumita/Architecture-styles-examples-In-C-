using Bogus;

namespace MyMusic.Application.CommandHandlers.Tests.builders {
    public static class ATrack {
        
        public static string Id = new Faker().Random.String2(64);
    }
}