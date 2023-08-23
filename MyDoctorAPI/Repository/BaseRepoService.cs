using Microsoft.EntityFrameworkCore;
using MyDoctorAPI.Data;

namespace FeliveryAPI.Repository
{
    public class BaseRepoService
    {
        public IDbContextFactory<MyDoctorAPIContext> Context { get; set; }
        public BaseRepoService(IDbContextFactory<MyDoctorAPIContext> context)
        {
            Context = context;
        }
    }
}
