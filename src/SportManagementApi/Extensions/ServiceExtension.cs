using SportManagement.Data.IRepositories;
using SportManagement.Data.Repositories;
using SportManagement.Service.Interfaces;
using SportManagement.Service.Services;

namespace SportManagementApi.Extensions
{
    public static class ServiceExtension
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IMatchInterface, MatchService>();
            services.AddScoped<IPlayerInterface, PlayerService>();
            services.AddScoped<IScoreInterFace, ScoreService>();
            services.AddScoped<ITeamInterface, TeamService>();
        }
    }
}
