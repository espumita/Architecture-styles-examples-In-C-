using Bogus;

namespace MyMusic.Api.Tests.EventHandlers {

    public static class APlaylist {
        public static string Id = new Faker().Random.String2(64);
        public static string Name = new Faker().Random.String2(64);
        public static string ImageUrl = new Faker().Random.String2(64);

    }
}